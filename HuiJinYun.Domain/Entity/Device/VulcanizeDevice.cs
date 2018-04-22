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
    public enum eVulcanizeState : UInt32
    {
        Null,
        AGVInLeave = 1 << 0,   //AGV入离开    48
        AGVOutLeave = 1 << 1,  //AGV出离开    49
        AGVSendTray = 1 << 2,  //AGV送盘      50
        AGVGetTray = 1 << 3,   //AGV收盘      51
        InNoAGVAlert = 1 << 4,   //入口无车预警   52
        OutNoAGVAlert = 1 << 5,  //出口无车报警   53
        InAndOutNoAGVFaultAler = 1 << 6,   //出入口无车故障报警    54
        InNoAGVFaultAlert = 1 << 7,  //入口无车故障报警      55
        OutNoAGVFaultAlert = 1 << 8,  //出口无车故障报警     56
        AGVInNear = 1 << 9,  //AGV入靠近                     57
        AGVOutNear = 1 << 10, //AGV出靠近                    58
        CoolerToExit = 1 << 11, //冷却到出口                  59
        VulcanizationDoorUp = 1 << 12,//硫化门升              60
        CoolerDoorUp = 1 << 13,  //冷却门升                   61
        VulcanizationToCooler = 1 << 14,  //硫化到冷却         62
        VulcanizationDoorDown = 1 << 15,   //硫化门降           63
        CoolerDoorDown = 1 << 16,  // 冷却门降                  64
        HandOpertionCoolerTransmission = 1 << 17,//手动冷却传送带动     65
        OutToAGV = 1 << 18,  //出口到小车      66
        Estop = 1 << 19, //急停                67
        ViceReset = 1 << 20  //从机复位                 68
    }


    public enum eVulcanizeOption
    {
        Null,
        AGVInWaiting = 1 << 0,  //小车入口等待    M80
        AGVExitWaiting = 1 << 1, //小车出口等待   M81
        OutDiscReady = 1 << 2,  //出盘已准备       M82
        VulcanizationDoorUpReady = 1 << 3, //硫化门已升    M83
        Reset = 1 << 4, //删除键      M84
        ExitToAGV = 1 << 5, //出口到小车   M85  
        VulcanizationDoorDownReady = 1 << 6,  //硫化门已降    M86
        CoolerReady = 1 << 7,  //硫化到冷却已完成    M87
        AlarmRelease = 1 << 8     //报警解除     M88
    }

    //主同步到副
    public delegate void SyncHandler(object sender,  eVulcanizeState state);

    /// <summary>
    /// 硫化道-主
    /// </summary>
    public class VulcanizeDevice : PlcDeviceBase
    {
        public event SyncHandler OnSync;

        protected eVulcanizeOption _option = default(eVulcanizeOption);
        protected eVulcanizeState _status = default(eVulcanizeState);
        public eVulcanizeState Status
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

        protected UInt16 _buffer;
        //protected Thread
        public VulcanizeDevice(IPort port, ISerialize serialize) : base(port, serialize)
        {
            try
            {
                lock (_port)
                {
                    _port.Write(_serialize.Serialize(new ReadRandomCommand(eElementCode.M, 5 * 16)))
                                   .Read(out byte[] result);
                    var res = _serialize.Deserialize<ReadRandomResult>(result);
                    if (res.Code == ePlcResultCode.OK)
                        _option = (eVulcanizeOption)res.WordData;
                }
            }
            catch(Exception ex) {
                Logger.ErrorInfo("VulcanizeDevice  读取状态", ex);
            }
            _isOnline = true;

            Reset(true); Thread.Sleep(1000);
            Reset(false);

            Update();
        }

        protected async void Update()
        {
            while (true)
            {
                var status = Task.Run(() =>
                {
                    eVulcanizeState newState = default(eVulcanizeState);
                    lock (_port)
                    {
                        byte[] result;
                        _port.Write(_serialize.Serialize(new ReadRandomCommand(eElementCode.M, 3 * 16)))
                             .Read(out result);
                        var res = _serialize.Deserialize<ReadRandomResult>(result);
                        if (ePlcResultCode.OK == res.Code)
                        {
                            newState = (eVulcanizeState)res.WordData;
                            //Sync
                            OnSync?.Invoke(this, newState);
                        }
                        _port.Write(_serialize.Serialize(new ReadRandomCommand(eElementCode.M, 4 * 16)))
                             .Read(out result);
                        res = _serialize.Deserialize<ReadRandomResult>(result);
                        if (ePlcResultCode.OK == res.Code)
                        {
                            try
                            {
                                newState |= (eVulcanizeState)((res.WordData << 16) & 0xFFFF0000);
                                //Sync
                                OnSync?.Invoke(this, newState);
                            }
                            catch(Exception ex) {
                                Logger.ErrorInfo("主同步副调用", ex);
                            }
                        }
                    }
                    Thread.Sleep(100);
                    return newState;
                });
                Status = await status;
            }
        }

        public void ViceSync(object sender, byte[] args, eVulcanizeViceState state)
        {
            var cmd = _serialize.Serialize(new WriteCommand(eElementCode.D, 50, 24))
                                .Concat(args).ToArray();
            lock (_port)
            {
                _port.Write(cmd)
                     .Read(out byte[] result);
                var data = _serialize.Deserialize<PlcResultBase>(result);
            }

            lock (_port)
            {
                //硫化门已升
                _option = (Bit.Tst(state, eVulcanizeViceState.VulcanizationDoorUpReady) ? Bit.Set(_option, eVulcanizeOption.VulcanizationDoorUpReady) : Bit.Clr(_option, eVulcanizeOption.VulcanizationDoorUpReady));
                //出盘已准备
                _option = (Bit.Tst(state, eVulcanizeViceState.OutDiscReady) ? Bit.Set(_option, eVulcanizeOption.OutDiscReady) : Bit.Clr(_option, eVulcanizeOption.OutDiscReady));
                //硫化门已降
                _option = (Bit.Tst(state, eVulcanizeViceState.VulcanizationDoorDownReady) ? Bit.Set(_option, eVulcanizeOption.VulcanizationDoorDownReady) : Bit.Clr(_option, eVulcanizeOption.VulcanizationDoorDownReady));
                //出口到小车
                _option = (Bit.Tst(state, eVulcanizeViceState.ExitToAGV) ? Bit.Set(_option, eVulcanizeOption.ExitToAGV) : Bit.Clr(_option, eVulcanizeOption.ExitToAGV));
                //硫化到冷却已完成
                _option = (Bit.Tst(state, eVulcanizeViceState.CoolerReady) ? Bit.Set(_option, eVulcanizeOption.CoolerReady) : Bit.Clr(_option, eVulcanizeOption.CoolerReady));

                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 5 * 16, (ushort)_option)));
                _port.Read(out byte [] result);

#if DEBUG
                var res = _serialize.Deserialize<WriteRandomResult>(result);

                Logger.LogInfo($"Vulcanize:ViceSync, code:{state.ToString()}");
                Logger.LogInfo($"Vulcanize:ViceSync, code:{res.Code.ToString()}");
#endif
            }
        }

        /// <summary>
        /// 小车入口等待
        /// </summary>
        /// <returns></returns>
        public IDevice AGVInWaiting(bool enable = true)
        {
            byte[] result;
            lock (_port)
            {
                _option = enable ? Bit.Set(_option, eVulcanizeOption.AGVInWaiting) : Bit.Clr(_option, eVulcanizeOption.AGVInWaiting);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 5 * 16, (ushort)_option)));
                _port.Read(out result);
            }
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"Vulcanize:AGVInWaiting, code:{res.Code.ToString()}");
#endif
            return this;
        }

        /// <summary>
        /// 小车出口等待
        /// </summary>
        /// <returns></returns>
        public IDevice AGVExitWaiting(bool enable = true)
        {
            byte[] result;
            lock (_port)
            {
                _option = enable ? Bit.Set(_option, eVulcanizeOption.AGVExitWaiting) : Bit.Clr(_option, eVulcanizeOption.AGVExitWaiting);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 5 * 16, (ushort)_option)));
                _port.Read(out result);
            }
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"Vulcanize:AGVExitWaiting, code:{res.Code.ToString()}");
#endif
            return this;
        }

        /// <summary>
        /// 出盘已准备
        /// </summary>
        /// <returns></returns>
        public IDevice OutDiscReady(bool enable = true)
        {
            byte[] result;
            lock (_port)
            {
                _option = enable ? Bit.Set(_option, eVulcanizeOption.OutDiscReady) : Bit.Clr(_option, eVulcanizeOption.OutDiscReady);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 5 * 16, (ushort)_option)));
                _port.Read(out result);
            }
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"Vulcanize:OutDiscReady, code:{res.Code.ToString()}");
#endif
            return this;
        }


        /// <summary>
        /// 硫化门已升
        /// </summary>
        /// <returns></returns>
        public IDevice VulcanizationDoorUpReady(bool enable = true)
        {
            byte[] result;
            lock (_port)
            {
                _option = enable ? Bit.Set(_option, eVulcanizeOption.VulcanizationDoorUpReady) : Bit.Clr(_option, eVulcanizeOption.VulcanizationDoorUpReady);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 5 * 16, (ushort)_option)));
                _port.Read(out result);
            }
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"Vulcanize:VulcanizationDoorUpReady, code:{res.Code.ToString()}");
#endif

            return this;
        }




        /// <summary>
        /// 硫化门已降
        /// </summary>
        /// <returns></returns>
        public IDevice VulcanizationDoorDownReady(bool enable = true)
        {
            byte[] result;
            lock (_port)
            {
                _option = enable ? Bit.Set(_option, eVulcanizeOption.VulcanizationDoorDownReady) : Bit.Clr(_option, eVulcanizeOption.VulcanizationDoorDownReady);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 5 * 16, (ushort)_option)));
                _port.Read(out result);
            }
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"Vulcanize:VulcanizationDoorDownReady, code:{res.Code.ToString()}");
#endif
            return this;
        }


        /// <summary>
        /// 出口到小车
        /// </summary>
        /// <returns></returns>
        public IDevice ExitToAGV(bool enable = true)
        {
            byte[] result;
            lock (_port)
            {
                _option = enable ? Bit.Set(_option, eVulcanizeOption.ExitToAGV) : Bit.Clr(_option, eVulcanizeOption.ExitToAGV);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 5 * 16, (ushort)_option)));
                _port.Read(out result);
            }
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"Vulcanize:ExitToAGV, code:{res.Code.ToString()}");
#endif

            return this;
        }


        /// <summary>
        /// 硫化到冷却已完成
        /// </summary>
        /// <returns></returns>
        public IDevice CoolerReady(bool enable = true)
        {
            byte[] result;
            lock (_port)
            {
                _option = enable ? Bit.Set(_option, eVulcanizeOption.CoolerReady) : Bit.Clr(_option, eVulcanizeOption.CoolerReady);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 5 * 16, (ushort)_option)));
                _port.Read(out result);
            }
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"Vulcanize:CoolingTransmissionFixedPulse, code:{res.Code.ToString()}");
#endif
            return this;
        }
        /// <summary>
        /// 报警解除(
        /// </summary>
        /// <returns></returns>
        public IDevice AlarmRelease(bool enable = true)
        {
            byte[] result;
            lock (_port)
            {
                _option = enable ? Bit.Set(_option, eVulcanizeOption.AlarmRelease) : Bit.Clr(_option, eVulcanizeOption.AlarmRelease);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 5 * 16, (ushort)_option)));
                _port.Read(out result);
            }
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"Vulcanize:AlarmRelease, code:{res.Code.ToString()}");
#endif
            return this;
        }


        public override void Reset(bool force = false)
        {
            byte[] result;
            lock (_port)
            {
                _option = force ? Bit.Set(_option, eVulcanizeOption.Reset) : Bit.Clr(_option, eVulcanizeOption.Reset);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 5 * 16, (ushort)_option)));
                _port.Read(out result);
            }
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"Vulcanize:Reset, code:{res.Code.ToString()}");
#endif
        }
    }
}
