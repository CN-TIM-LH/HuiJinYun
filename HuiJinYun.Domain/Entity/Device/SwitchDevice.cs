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

    /*  旧版
    public enum eSwitchState
    {
        Null,
        EStop = 1 << 0,            //急停指示        （包胶|解胶)
        SwitchTimeOut = 1 << 1,   //交换超时报警     （包胶|解胶)
        SwitchFault = 1 << 2,     //交换故障报警     （包胶|解胶)
        Unclamped1 = 1 << 3,      //松开1信号        （包胶|解胶)
        Clamped1 = 1 << 4,        //夹紧1信号        （包胶|解胶)
        Rotated = 1 << 5,         //旋转到位信号     （包胶|解胶)
        SwitchEnd = 1 << 6,        //交换结束信号    （包胶|解胶)
        CylinderFault = 1 << 7,    //气缸不到位报警  （包胶|解胶)
        Unclamped2 = 1 << 8,      //松开2信号
        Clamped2 = 1 << 9,        //夹紧2信号
        SwitchUpDownCylinder = 1 << 10,     //交换升降气缸
        SwitchCylinder1 = 1 << 11,     //交换气缸1
        SwitchCylinder2 = 1 << 12,     //交换气缸2
    }*/

    public enum eSwitchState
    {
        Null,
        EStop = 1 << 0,            //急停指示 16         急停指示(缠绕六工位)
        Unclamped0 = 1 << 1,      //松开1信号 17         旋转完成(缠绕六工位)
        Clamped0 = 1 << 2,        //夹紧1信号 18         取盘完成(缠绕六工位)
        Unclamped1 = 1 << 3,      //松开2信号 19         放盘完成(缠绕六工位)
        Clamped1 = 1 << 4,        //夹紧2信号 20
        Unclamped2 = 1 << 5,      //松开3信号 21
        Clamped2 = 1 << 6,        //夹紧3信号 22
        Unclamped3 = 1 << 7,      //松开4信号 23
        Clamped3 = 1 << 8,        //夹紧4信号 24
        Unclamped4 = 1 << 9,      //松开5信号 25
        Clamped4 = 1 << 10,        //夹紧5信号 26
        Unclamped5 = 1 << 11,      //松开6信号 27
        Clamped5 = 1 << 12,        //夹紧6信号 28
        Rotate  = 1 << 13,         //工位旋转  29
    }

    /*
    public enum eSwitchOption
    {
        Null,
        Reset = 1 << 0,      //复位                 （包胶|解胶)
        Clamp = 1 << 1,      //夹件/松件            （包胶|解胶)
        Rotate = 1 << 2,     //工位旋转             （包胶|解胶)
        Switch = 1 << 3,     //启动交换             （包胶|解胶)
        EStop = 1 << 4,      //急停                 （包胶|解胶)
        Operate = 1 << 5,    //工控机控制           （包胶|解胶)
        Clamp2 = 1<< 6       //夹件/松件2           （包胶|解胶)
    }*/
    public enum eSwitchOption
    {
        Null,
        Clamp0 = 1 << 0,        //夹件/松件1   32     旋转(缠绕六工位)
        Clamp1 = 1 << 1,        //夹件/松件2   33     取盘(缠绕六工位)
        Clamp2 = 1 << 2,        //夹件/松件3   34     放盘(缠绕六工位)
        Clamp3 = 1 << 3,        //夹件/松件4   35     急停(缠绕六工位)
        Clamp4 = 1 << 4,        //夹件/松件5   36     旋转完成复位(缠绕六工位)
        Clamp5 = 1 << 5,        //夹件/松件6   37
        Operate = 1 << 6,       //工控机控制   38     工控机控制(缠绕六工位)
        Rotate = 1 << 7,        //工位旋转     39
        EStop = 1 << 8,         //急停         40
    }

    /// <summary>
    /// 交换台
    /// </summary>
    public class SwitchDevice : PlcDeviceBase
    {
        protected volatile dynamic _option = default(eSwitchOption);
        protected volatile dynamic _status = default(eSwitchState);
        public eSwitchState Status
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

        public SwitchDevice(IPort port, ISerialize serialize) : base(port, serialize)
        {
            _port.Write(_serialize.Serialize(new ReadRandomCommand(eElementCode.M, 2 * 16)))
                 .Read(out byte[] result);
            var res = _serialize.Deserialize<ReadRandomResult>(result);
            if (res.Code == ePlcResultCode.OK)
                _option = (eSwitchOption)res.WordData;
            _isOnline = true;
            Update();
        }

        protected async void Update()
        {
            while (true)
            {
                var status = Task.Run(() =>
                {
                    byte[] result;
                    eSwitchState newState = default(eSwitchState);

                    lock (_port)
                    {
                        _port.Write(_serialize.Serialize(new ReadRandomCommand(eElementCode.M, 1 * 16)))
                             .Read(out result);
                    }
                    if (null != result)
                    {
                        var res = _serialize.Deserialize<ReadRandomResult>(result);
                        if (res.Code == ePlcResultCode.OK)
                            newState = (eSwitchState)res.WordData;
                    }
                    Thread.Sleep(100);
                    return newState;
                });
                Status = await status;
            }
        }

        /// <summary>
        /// 夹件|松件信号
        /// </summary>
        /// <param name="number"></param>
        /// <param name="enable"></param>
        public IDevice Clamp(int number, bool enable = true)
        {
            eSwitchOption clamp;
            switch (number)
            {
                case 0: clamp = eSwitchOption.Clamp0; Bit.Clr(_status, eSwitchState.Unclamped0); break;
                case 1: clamp = eSwitchOption.Clamp1; Bit.Clr(_status, eSwitchState.Unclamped0); break;
                case 2: clamp = eSwitchOption.Clamp2; break;
                case 3: clamp = eSwitchOption.Clamp3; break;
                case 4: clamp = eSwitchOption.Clamp4; break;
                case 5: clamp = eSwitchOption.Clamp5; break;
                default: return this;
            }

            byte[] result;
            lock (_port)
            {
               
                _option = enable ? Bit.Set(_option, clamp) : Bit.Clr(_option, clamp);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 2 * 16, (ushort)_option)))
                    .Read(out result);
            }
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"Switch:{clamp.ToString()} {enable}, code:{res.Code.ToString()}");
#endif
            return this;
        }

        /// <summary>
        /// 旋转
        /// </summary>
        /// <returns></returns>
        public IDevice Rotate(bool enable = true)
        {
            byte[] result;
            lock (_port)
            {
                Bit.Clr(_status, eSwitchState.Rotate);
                _option = enable ? Bit.Set(_option, eSwitchOption.Rotate) : Bit.Clr(_option, eSwitchOption.Rotate);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 2 * 16, (ushort)_option)))
                  .Read(out result);
                //_option = Bit.Clr(_option, eSwitchOption.Rotate);
                //_port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 2 * 16, (ushort)_option)));
                //_option = enable ? Bit.Set(_option, eSwitchOption.Rotate);
                //_port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 2 * 16, (ushort)_option)));
                //_port.Read(out result);
            }
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"Switch:rotate, code:{res.Code.ToString()}");
#endif
            return this;
        }


        /// <summary>
        /// 启动交换
        /// </summary>
        /// <returns></returns>
        public IDevice Switch()
        {
            byte[] result;
           /* lock (_port)
            {
                
                _option = Bit.Clr(_option, eSwitchOption.Switch);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 2 * 16, (ushort)_option)));
                _option = Bit.Set(_option, eSwitchOption.Switch);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 2 * 16, (ushort)_option)));
                _port.Read(out result);
            }
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"Switch:switch, code:{res.Code.ToString()}");
#endif
*/
            return this;
        }

        /// <summary>
        /// 工控机控制
        /// </summary>
        /// <returns></returns>
        public IDevice Operate(bool enable)
        {
            byte[] result;
            lock (_port)
            {
                _option = enable ? Bit.Set(_option, eSwitchOption.Operate) : Bit.Clr(_option, eSwitchOption.Operate);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 2 * 16, (ushort)_option)))
                    .Read(out result);
            }
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"Switch:operate {enable}, code:{res.Code.ToString()}");
#endif
            return this;
        }

        /// <summary>
        /// 急停
        /// </summary>
        /// <returns></returns>
        public IDevice EStop(bool enable)
        {
            byte[] result;
            lock (_port)
            {
                _option = enable ? Bit.Set(_option, eSwitchOption.EStop) : Bit.Clr(_option, eSwitchOption.EStop);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 2 * 16, (ushort)_option)))
                    .Read(out result);
            }
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"Switch:estop {enable}, code:{res.Code.ToString()}");
#endif
            return this;
        }

        /// <summary>
        /// 复位
        /// </summary>
        /// <param name="force">强制复位</param>
        public override void Reset(bool force = false)
        {
            byte[] result;
        }
    }
}
