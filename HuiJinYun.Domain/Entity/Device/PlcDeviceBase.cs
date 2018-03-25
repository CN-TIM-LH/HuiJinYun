using HuiJinYun.Domain.Entity.PLC;
using HuiJinYun.Domain.Infrastructure.Common;
using HuiJinYun.Domain.Infrastructure.Port;
using HuiJinYun.Domain.Infrastructure.Watcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.Device
{
    public delegate void DeviceStateChangedEventHandler(object sender, DeviceStateChangeEventArgs args);

    public abstract class PlcDeviceBase : IDevice
    {
        protected ISerialize _serialize;
        protected IPort _port;
        protected string _password;

        protected ePlcModel _model = ePlcModel.Null;
        public virtual ePlcModel Model
        {
            get
            {
                if (ePlcModel.Null == _model)
                {
                    byte[] result;
                    lock (_port)
                    {
                        _port.Write(_serialize.Serialize<ReadTypeNameCommand>(new ReadTypeNameCommand()))
                            .Read(out result);
                    }
                    if (null != result)
                    {
                        var res = _serialize.Deserialize<ReadTypeNameResult>(result);
                        _model = res.Model;
                    }
                }
                return _model;
            }
        }

        protected bool _isOnline = false;
        public virtual bool isOnline => _isOnline;

        protected bool _lock = true;
        public virtual bool Lock
        {
            get
            {
                return _lock;
            }
            set
            {
                byte[] data;
                if (value)
                    data = _serialize.Serialize<PasswordLockCommand>(new PasswordLockCommand(_password));
                else
                    data = _serialize.Serialize<PasswordUnlockCommand>(new PasswordUnlockCommand(_password));
                _port.Write(data).Read(out data);
                if(ePlcResultCode.OK == _serialize.Deserialize<PlcResultBase>(data).Code)
                    _lock = value;
            }
        }
        
        public event NotifyEventHandler OnNotify;

        protected void StateChanged(DeviceStateChangeEventArgs args) => OnNotify?.Invoke(this, args);

        protected PlcDeviceBase(IPort port, ISerialize serialize, string password = "UQ5mRERZdGsxdX7G")
        {
            _port = port;
            _serialize = serialize;
        }

        /// <summary>
        /// 复位
        /// </summary>
        /// <param name="force">强制复位</param>
        public abstract void Reset(bool force = false);
    }
}
