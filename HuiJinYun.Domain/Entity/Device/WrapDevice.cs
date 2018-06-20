using HuiJinYun.Domain.Entity.PLC;
using HuiJinYun.Domain.Infrastructure.Common;
using HuiJinYun.Domain.Infrastructure.Port;
using HuiJinYun.Domain.Log;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.Device
{
    public enum eWrapState
    {
        Null,
        PickUp = 1 << 0,   //取件
        WrapEnd = 1 << 1,  //包胶结束
        PickUpEnd = 1 << 2,   //取件完成
        ToZero = 1 << 3       //回零预约
    }

    public enum eWrapOption
    {
        Null,
        EStop = 1 << 0,   //急停   32
        Picked = 1 << 1,  // 夹件完成  33
        IPCCMD = 1 << 2,  //工控机控制  34
        Placing = 1 << 3,  //松件    35
    }

    /// <summary>
    /// 包胶机
    /// </summary>
    public class WrapDevice : PlcDeviceBase
    {
        protected volatile dynamic _option = default(eWrapOption);
        protected volatile dynamic _status = default(eWrapState);
        public volatile int ZeroTimestamp = int.MaxValue;

        public eWrapState Status
        {
            get {
                return _status;
            }
            set {
                if (_status != value)
                {
                    var changed = _status ^ value;
                    _status = value;
                    StateChanged(new DeviceStateChangeEventArgs(changed));
                }
            }
        }

        public WrapDevice(IPort port, ISerialize serialize) : base(port, serialize)
        {
                _port.Write(_serialize.Serialize(new ReadRandomCommand(eElementCode.M, 2 * 16)))
                    .Read(out byte[] result);
                var res = _serialize.Deserialize<ReadRandomResult>(result);
                if (res.Code == ePlcResultCode.OK)
                    _option = (eWrapOption)res.WordData;
            _isOnline = true;

            EStop(true); Thread.Sleep(1000);
            EStop(false);

            Update();
        }

        public async void Update()
        {
            while (true)
            {

                var status = Task.Run(() =>
                {
                    byte[] result;
                    eWrapState newState = default(eWrapState);
                    lock (_port)
                    {
                        _port.Write(_serialize.Serialize(new ReadRandomCommand(eElementCode.M, 1 * 16)))
                             .Read(out result);
                        if (null != result)
                        {
                            var res = _serialize.Deserialize<ReadRandomResult>(result);
                            if (res.Code == ePlcResultCode.OK)
                                newState = (eWrapState)res.WordData;
                        }
                    }
                    Thread.Sleep(100);
                    return newState;
                });
                Status = await status;
                
                if ((int.MaxValue <= ZeroTimestamp) && Bit.Tst(Status, eWrapState.ToZero))
                {
                    DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
                    ZeroTimestamp = (int)(DateTime.Now - startTime).TotalSeconds;
                }
            }
        }

        /// <summary>
        /// 夹件|松件
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public IDevice Placing(bool enable = true)
        {
            byte[] result;
            lock (_port)
            {
                _option = enable ? Bit.Set(_option, eWrapOption.Placing) : Bit.Clr(_option, eWrapOption.Placing);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 2 * 16, (ushort)_option)));
                _port.Read(out result);
            }
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"Wrap:Placing, code:{res.Code.ToString()}");
#endif
            return this;
        }

        /// <summary>
        /// 夹件完成
        /// </summary>
        /// <param name="enable"></param>
        /// <returns></returns>
        public IDevice Clamped(bool enable = true)
        {
            byte[] result;
            lock (_port)
            {
                _option = enable ? Bit.Set(_option, eWrapOption.Picked) : Bit.Clr(_option, eWrapOption.Picked);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 2 * 16, (ushort)_option)));
                _port.Read(out result);
            }

#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"Wrap:Clamped, code:{res.Code.ToString()}");
#endif

            return this;
        }


        /// <summary>
        /// 工控机控制
        /// </summary>
        /// <param name="enable"></param>
        /// <returns></returns>
        public IDevice IPCCMD(bool enable = true)
        {
            byte[] result;
            lock (_port)
            {
                _option = enable ? Bit.Set(_option, eWrapOption.IPCCMD) : Bit.Clr(_option, eWrapOption.IPCCMD);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 2 * 16, (ushort)_option)));
                _port.Read(out result);
            }

#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"Wrap:Clamped, code:{res.Code.ToString()}");
#endif

            return this;
        }



        /// <summary>
        /// 急停
        /// </summary>
        /// <param name="enable"></param>
        /// <returns></returns>
        public IDevice EStop(bool enable = true)
        {
            byte[] result;
            lock (_port)
            {
                _option = enable ? Bit.Set(_option, eWrapOption.EStop) : Bit.Clr(_option, eWrapOption.EStop);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 2 * 16, (ushort)_option)));
                _port.Read(out result);
            }
            ZeroTimestamp = int.MaxValue;
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"Wrap:EStop, code:{res.Code.ToString()}");
#endif

            return this;
        }

       
        public override void Reset(bool force = false)
        {
            throw new NotImplementedException();
        }
    }
}