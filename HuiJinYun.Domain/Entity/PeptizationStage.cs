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
    public delegate void SyncSwitchHandler(object sender, SyncU3D sync);

    /// <summary>
    /// 解胶
    /// </summary>
    public class PeptizationStage : IProductionStage
    {
        protected SwitchDevice _switch;
        protected int _count;
        public eProductionStageState Status { get; protected set; } = eProductionStageState.Stop;
        public static event SyncSwitchHandler OnSync;
        public PeptizationStage(SwitchDevice @switch)
        {
            _switch = @switch;
        }

        public IProductionStage Bypass(object args, out object result)
        {
            var context = (HuiJinYunProductionContext)args;

            Status = eProductionStageState.Ready;
            /*
            new NotifyWatcher(_switch).WaitOne((s, a) => eHuiJinYunStagePosition.Peptization == context.Position, 1000);
            _switch.Switch();
            Thread.Sleep(10000);
            new NotifyWatcher(_switch).WaitOne((s, a) => { return Bit.Tst(_switch.Status, eSwitchState.SwitchEnd); }, 1000);*/
            context.CurrentAGV.State = eHuiJinYunAGVState.Tray;
            Status = eProductionStageState.Finish;
            result = null;
            return this;
        }

        public async Task<IProductionStage> Work(object args)
        {
            return this;
        }

        public IProductionStage Work(object args, out object result)
        {
            var context = (HuiJinYunProductionContext)args;
#if DEBUG
            Logger.LogInfo($"PeptizationStage Start");
#endif
            /*
            Status = eProductionStageState.Busy;
            _switch.Reset(); Thread.Sleep(1000);
            _switch.Reset(false);
            new NotifyWatcher(_switch).WaitOne((s, a) => { return Bit.Tst(_switch.Status, eSwitchState.SwitchEnd); }, 1000);
            Thread.Sleep(5000);
            _switch.Reset(); Thread.Sleep(1000); _switch.Reset(false);
            SyncU3D sync = new SyncU3D() { type = eSyncU3D.Switch, number = 1, Operate = true };
            OnSync?.Invoke(this, sync);
            Status = eProductionStageState.Ready;
            //while (eHuiJinYunStagePosition.Peptization != context.Position) Thread.Sleep(1000);
            //_switch.Switch();
            */
            context.CurrentAGV.State = eHuiJinYunAGVState.Mould;
            Status = eProductionStageState.Finish;

            result = null;
#if DEBUG
            Logger.LogInfo($"PeptizationStage Finish");
#endif
            return this;
        }
    }
}
