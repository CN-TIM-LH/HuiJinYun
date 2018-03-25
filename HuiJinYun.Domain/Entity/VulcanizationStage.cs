using HuiJinYun.Domain.Entity.AGV;
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
    public delegate void SyncDoorHandler(object sender, SyncU3D sync);

    /// <summary>
    /// 硫化阶段
    /// </summary>
    public class VulcanizationStage : IProductionStage
    {
        protected VulcanizeDevice _vulcanize;
        protected VulcanizeViceDevice _vulcanizeVice;
        public static event SyncDoorHandler OnSync;
        public eProductionStageState Status { get; protected set; }
        public VulcanizationStage(VulcanizeDevice vulcanize, VulcanizeViceDevice vulcanizeVice)
        {
            _vulcanize = vulcanize;
            _vulcanizeVice = vulcanizeVice;

            _vulcanize.Reset();
            _vulcanizeVice.Reset(); Thread.Sleep(1000);
            _vulcanize.Reset(false);
            _vulcanizeVice.Reset(false);

            //主副信息同步
            _vulcanize.OnSync += _vulcanizeVice.Sync;
            _vulcanizeVice.OnViceSync += _vulcanize.ViceSync;
#if DEBUG
            Logger.LogInfo($"Vulcanize -VulcanizeVice:Sync cmd");
#endif

        }
        public IProductionStage Bypass(object args, out object result)
        {
            var context = (HuiJinYunProductionContext)args;
            result = null;
            return this;
        }

        public IProductionStage Work(object args, out object result)
        {
            bool stageDone;
            stageDone = false;
            var context = (HuiJinYunProductionContext)args;
            while (eHuiJinYunStagePosition.Vulcanization != context.Position) ;

            try
            {
                Bit.Clr(_vulcanize.Status, eVulcanizeState.AGVInLeave);
                while (!Bit.Tst(_vulcanize.Status, eVulcanizeState.AGVInLeave)) Thread.Sleep(1000);
                Thread.Sleep(1000);
                _vulcanize.AGVInWaiting(false);
                context.CurrentAGV.Export(eHuiJinYunStagePosition.Initial, 1, false);
            }
            catch {

            }
            context.CurrentAGV.State = eHuiJinYunAGVState.Empty;
            result = null;
            return this;
        }

         #region Update
        public async void Update()
        {
            while (true)
            {
                SyncU3D sync = null;
                var status = Task.Run(() =>
                {
                    if (Bit.Tst(_vulcanize.Status, eVulcanizeState.VulcanizationDoorUp))
                    {
                        sync = new SyncU3D() { type = eSyncU3D.Vulcanize, number = 1, Operate = true };
                    };
                    if (Bit.Tst(_vulcanize.Status, eVulcanizeState.VulcanizationDoorDown))
                    {
                        sync = new SyncU3D() { type = eSyncU3D.Vulcanize, number = 2, Operate = true };
                    };
                    if (Bit.Tst(_vulcanize.Status, eVulcanizeState.CoolerDoorUp))
                    {
                        sync = new SyncU3D() { type = eSyncU3D.Vulcanize, number = 3, Operate = true };
                    };
                    if (Bit.Tst(_vulcanize.Status, eVulcanizeState.CoolerDoorDown))
                    {
                        sync = new SyncU3D() { type = eSyncU3D.Vulcanize, number = 4, Operate = true };
                    };
                    

                    if (Bit.Tst(_vulcanizeVice.Status, eVulcanizeViceState.CoolerDoorUpReady))
                    {
                        sync = new SyncU3D() { type = eSyncU3D.Vulcanize, number =5, Operate = true };
                    };
                    if (Bit.Tst(_vulcanizeVice.Status, eVulcanizeViceState.CoolerDoorDownReady))
                    {
                        sync = new SyncU3D() { type = eSyncU3D.Vulcanize, number = 6, Operate = true };
                    };
                    if (Bit.Tst(_vulcanizeVice.Status, eVulcanizeViceState.VulcanizationDoorUpReady))
                    {
                        sync = new SyncU3D() { type = eSyncU3D.Vulcanize, number = 7, Operate = true };
                    };
                    if (Bit.Tst(_vulcanizeVice.Status, eVulcanizeViceState.VulcanizationDoorDownReady))
                    {
                        sync = new SyncU3D() { type = eSyncU3D.Vulcanize, number = 8, Operate = true };
                    };

                    Thread.Sleep(1000);
                    return sync;
                });
                sync = await status;
                OnSync?.Invoke(this, sync);
                Thread.Sleep(5000);
            }
        }
        #endregion
    }
}
