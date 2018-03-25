using HuiJinYun.Domain.Entity.Device;
using HuiJinYun.Domain.Enum;
using HuiJinYun.Domain.Infrastructure.Watcher;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity
{
    /// <summary>
    ///缠绕
    /// </summary>
    public class EnlaceStage : IProductionStage
    {
        protected SwitchDevice _switch;
        protected EnlaceDevice _enlace;
        protected Task _runningTask;
        public eProductionStageState Status { get; protected set; }

        public EnlaceStage(SwitchDevice @switch, EnlaceDevice enlace)
        {
            _switch = @switch;
            _enlace = enlace;
        }

        public IProductionStage Bypass(object args, out object result)
        {
            var context = (HuiJinYunProductionContext)args;
            result = null;
            return this;
        }

        public IProductionStage Work(object args, out object result)
        {
            var context = (HuiJinYunProductionContext)args;

            if (null != _runningTask)
                _runningTask.Wait();
            new NotifyWatcher(context).WaitOne((s, a) => eHuiJinYunStagePosition.Enlace == context.Position, 1000);
            _switch.Switch();

            _runningTask = Task.Run(() =>
            {
                Status = eProductionStageState.Ready;
                context.CurrentAGV.State = eHuiJinYunAGVState.Product;
                Status = eProductionStageState.Finish;
            });

            result = null;
            return this;
        }
    }
}
