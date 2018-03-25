using HuiJinYun.Domain.Entity.Device;
using HuiJinYun.Domain.Infrastructure.Common;
using HuiJinYun.Domain.Infrastructure.Port;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuiJinYun.Domain.Infrastructure.Watcher;

namespace HuiJinYun.Domain.Entity.Device
{
  public abstract  class UwantAgvDeviceBase:IDevice
    {
        protected ISerialize _serialize;
        protected IPort _port;

        protected bool _isOnline = false;

        public event NotifyEventHandler OnNotify;

        public virtual bool isOnline => _isOnline;

        //public event DeviceStateChangedEventHandler OnStateChanged;

        protected UwantAgvDeviceBase(IPort port, ISerialize serialize)
        {
            _port = port;
            _serialize = serialize;
        }

        protected void StateChanged(EventArgs args)
        {
            //OnStateChanged?.Invoke(this, args);
        }
    }
}
