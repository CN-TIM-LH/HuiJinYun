using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuiJinYun.Domain.Infrastructure.Common;
using HuiJinYun.Domain.Infrastructure.Port;
using HuiJinYun.Domain.Entity.PLC;
using System.Threading;
using HuiJinYun.Domain.Log;

namespace HuiJinYun.Domain.Entity.Device
{
    public enum eEnlaceState
    {
        Null,
        TurntableClamping = 1 << 0,      //周转盘夹紧
        RevolvingDiskRotation = 1 << 1,  //周转盘旋转
        TurntableUndone = 1 << 2,        //周转盘松开
    }

    public enum eEnlaceOption
    {
        Null,
        RevolvingDiscInPlace = 1 << 0,      //周转盘旋转到位
        TurntableClampingReady = 1 << 1,   //周转盘夹紧完成
        Reset = 1 << 2,                    //一键复位
        Start = 1 << 3,                    //启动
        UnRevolvingDisc = 1 << 4,           // 周转盘松开
    }
    /// <summary>
    /// 缠绕机
    /// </summary>
    public class EnlaceDevice : PlcDeviceBase
    {
        protected volatile dynamic  _option = default(eEnlaceOption);
        protected volatile dynamic  _status = default(eEnlaceState);
        public eEnlaceState Status
        {
            get
            {
                return _status;
            }
            protected set
            {
                if (_status != value)
                {
                    var changed = _status ^ value;
                    _status = value;
                    StateChanged(new DeviceStateChangeEventArgs(changed));
                }
            }
        }

        public EnlaceDevice(IPort port, ISerialize serialize) : base(port, serialize)
        {
            _port.Write(_serialize.Serialize(new ReadRandomCommand(eElementCode.M, 3 * 16)))
                 .Read(out byte[] result);
            var res = _serialize.Deserialize<ReadRandomResult>(result);
            if (res.Code == ePlcResultCode.OK)
                _option = (eEnlaceOption)res.WordData;
            _isOnline = true;

            Reset(true);Thread.Sleep(1000);
            Reset(false);

            Update();
        }

        protected async void Update()
        {
            while (true)
            {
                var status = Task.Run(() =>
                {
                    byte[] result;
                    eEnlaceState newState = default(eEnlaceState);
                    lock (_port)
                    {
                        _port.Write(_serialize.Serialize(new ReadRandomCommand(eElementCode.M, 2 * 16)))
                             .Read(out result);
                    }
                    if (null != result)
                    {
                        var res = _serialize.Deserialize<ReadRandomResult>(result);
                        if (res.Code == ePlcResultCode.OK)
                            newState = (eEnlaceState)res.WordData;
                    }
                    Thread.Sleep(100);
                    return newState;
                });
                Status = await status;
            }
        }

        /// <summary>
        /// 周转盘旋转到位信号
        /// </summary>
        /// <returns></returns>
        public IDevice RevolvingDiscInPlace(bool enable =true)
        {
            byte[] result;
            lock (_port)
            {
                _option = enable ? Bit.Set(_option, eEnlaceOption.RevolvingDiscInPlace) : Bit.Clr(_option, eEnlaceOption.RevolvingDiscInPlace);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 3 * 16, (ushort)_option)))
                      .Read(out result);

            }
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"Enlace:RevolvingDiscInPlace {enable}, code:{res.Code.ToString()}");
#endif
            return this;
        }

        /// <summary>
        /// 周转盘夹紧完成
        /// </summary>
        /// <returns></returns>
        public IDevice TurntableClampingReady(bool enable =true)
        {
            byte[] result;
            lock (_port)
            {
                Bit.Clr(_status, eEnlaceState.RevolvingDiskRotation);
                _option = enable ? Bit.Set(_option, eEnlaceOption.TurntableClampingReady) : Bit.Clr(_option, eEnlaceOption.TurntableClampingReady);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 3 * 16, (ushort)_option)))
                      .Read(out result);
            }
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"Enlace:TurntableClampingReady {enable}, code:{res.Code.ToString()}");
#endif
            return this;
        }


        /// <summary>
        /// 启动
        /// </summary>
        /// <param name="enable"></param>
        /// <returns></returns>
        public IDevice Start(bool enable = true)
        {
            byte[] result;
            lock (_port)
            {
                _option = enable ? Bit.Set(_option, eEnlaceOption.Start) : Bit.Clr(_option, eEnlaceOption.Start);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 3 * 16, (ushort)_option)))
                      .Read(out result);
            }
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"Enlace:Start {enable}, code:{res.Code.ToString()}");
#endif
            return this;
        }


        /// <summary>
        /// 周转盘松开
        /// </summary>
        /// <param name="enable"></param>
        /// <returns></returns>
        public IDevice UnRevolvingDisc(bool enable = true)
        {
            byte[] result;
            lock (_port)
            {
                _option = enable ? Bit.Set(_option, eEnlaceOption.UnRevolvingDisc) : Bit.Clr(_option, eEnlaceOption.UnRevolvingDisc);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 3 * 16, (ushort)_option)))
                      .Read(out result);
            }
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"Enlace:UnRevolvingDisc {enable}, code:{res.Code.ToString()}");
#endif
            return this;
        }

        public override void Reset(bool force = false)
        {
            byte[] result;
            lock (_port)
            {
                _option = Bit.Clr(_option, eEnlaceOption.Reset);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 3 * 16, (ushort)_option)));
                _option = Bit.Set(_option, eEnlaceOption.Reset);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 3 * 16, (ushort)_option)));
                _port.Read(out result);
                _option = default(eEnlaceOption);
                Status = default(eEnlaceState);
            }
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"Enlace:reset, code:{res.Code.ToString()}");
#endif
        }
    }
}
