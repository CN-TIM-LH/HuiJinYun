using HuiJinYun.Domain.Entity.Device;
using HuiJinYun.Domain.Enum;
using HuiJinYun.Domain.Infrastructure.Common;
using HuiJinYun.Domain.Infrastructure.Watcher;
using HuiJinYun.Domain.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity
{
    //包胶机设备
    public class Encapsulation
    {
        public int Id { get; set; }
        public string DeviceName { get; set; }
        public bool IsBusy { get; set; }

        public bool isOnline { get; set; }
    }

    public class HuiJinYunProductionContext : IProductionContext
    {
        public int SN { get; }
        public bool isStart { get; set; } = true;


        public List<Encapsulation> _encapsulationDevice =new List<Encapsulation> ();
        public List<Encapsulation> EncapsulationDevice
        {
            get
            {
                return _encapsulationDevice;
            }
            set
            {
                EncapsulationDevice = _encapsulationDevice;
            }
        }

        protected HuiJinYunProductionLine _line;
        public IAGV<eHuiJinYunAGVState, eHuiJinYunStagePosition> CurrentAGV { get; protected set; }
        protected eHuiJinYunStagePosition _position = default(eHuiJinYunStagePosition);
        public eHuiJinYunStagePosition Position
        {
            get
            {
                return _position;
            }
            protected set
            {
                _position = value;
                StateChanged();
            }
        }
        public List<IProductionStage> Stages => _line.Stages;
        public IProductionStage CurrentStage => Stages[((Position & ~eHuiJinYunStagePosition.OnGoing) - eHuiJinYunStagePosition.Initial - 1)];
        #region Notify
        public event NotifyEventHandler OnNotify;
        protected void StateChanged() => OnNotify?.Invoke(this, null);
        #endregion
        public HuiJinYunProductionContext(
            HuiJinYunProductionLine line,
            IAGV<eHuiJinYunAGVState, eHuiJinYunStagePosition> currentAGV)
        {
            _line = line;
            CurrentAGV = currentAGV;
        }

        public Task<bool> Initial()
        {
            return Task.Run(() =>
            {
                var target = eHuiJinYunStagePosition.Initial;
                Position = target | eHuiJinYunStagePosition.OnGoing;
                CurrentAGV.Goto(target, (int)AGV.eSpeed.Speed4);
                //new NotifyWatcher(CurrentAGV).WaitOne((s, a) => CurrentAGV.Position == target);
                while (CurrentAGV.Position != target) { Logger.LogInfo($"AGV-Position:{CurrentAGV.Position},AGV-Position:{target}"); Thread.Sleep(1000); }
                Position = target;
                return true;
            });
        }

        public Task<bool> Work()
        {
            return Task.Run(() =>
            {
                if (null != CurrentStage)
                {
                    object result;
                    CurrentStage.Work(this, out result);
                    return true;
                }
                return false;
            });
        }

        public Task<bool> asyncWork()
        {
            return Task.Run(() =>
            {
                if (null != CurrentStage)
                {
                    CurrentStage.Work(this).Wait();
                    return true;
                }
                return false;
            });
        }

        public Task<bool> Bypass()
        {
            return Task.Run(() =>
            {
                if (null != CurrentStage)
                {
                    object result;
                    CurrentStage.Bypass(this, out result);
                    return true;
                }
                return false;
            });
        }

        public Task<bool> NextStage()
        {
            if (Position < eHuiJinYunStagePosition.Finish)
            {
                var target = (Position + 1);
                Position = target | eHuiJinYunStagePosition.OnGoing;
                return Task.Run(() =>
                {
                    CurrentAGV.Goto(target, (int)AGV.eSpeed.Speed4);
                    // new NotifyWatcher(CurrentAGV).WaitOne((s, a) => CurrentAGV.Position == target);
                    while (CurrentAGV.Position != target) { Logger.LogInfo($"AGV-Position:{CurrentAGV.Position},AGV-Position:{target}"); Thread.Sleep(1000); }
                    Position = target;
                    return true;
                });
            }
            return Task.FromResult<bool>(false);
        }
    }
}
