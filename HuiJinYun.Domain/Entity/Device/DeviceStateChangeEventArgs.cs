using HuiJinYun.Domain.Infrastructure.Watcher;

namespace HuiJinYun.Domain.Entity.Device
{
    public class DeviceStateChangeEventArgs : NotifyArgs
    {
        public object ChangedState { get; protected set; }

        public DeviceStateChangeEventArgs(object changedState)
        {
            ChangedState = changedState;
        }
    }
}
