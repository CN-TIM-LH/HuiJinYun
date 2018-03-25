using HuiJinYun.Domain.Entity.PLC;
using HuiJinYun.Domain.Infrastructure.Common;
using HuiJinYun.Domain.Infrastructure.Port;
using HuiJinYun.Domain.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.Device
{
    public enum eVulcanizeViceState
    {
        Null,
        VulcanizationDoorUpReady = 1 << 0,   //硫化门已升 32
        CoolerDoorUpReady = 1 << 1,  //冷却门已升         33
        OutDiscReady = 1 << 2,   //出盘已准备             34
        VulcanizationDoorDownReady = 1 << 3,  //硫化门已降    35
        CoolerDoorDownReady = 1 << 4, //冷却门已降            36
        ExitToAGV = 1 << 5,       //出口到小车                37
        CoolerReady = 1 << 6     // 硫化到冷却已完成          38
    }

    public enum eVulcanizeViceOption
    {
        Null,
        CoolerDoorUp = 1 << 0,   //冷却门升    48
        VulcanizationDoorUp = 1 << 1,  //硫化门升   49
        CoolerToExit = 1 << 2,   //冷却到出口    50
        VulcanizationDoorDown = 1 << 3,  //硫化门降    51
        CoolerDoorDown = 1 << 4,   //冷却门降     52
        HandOpertionCoolerTransmission = 1 << 5, //手动冷却传送动    53
        OutToAGV = 1 << 6,  //出口到小车      54
        CoolerReady = 1 << 7, //硫化到冷却     55
        EStop = 1 << 8,  //急停     56
        Reset = 1 << 9,   //复位        57
        IPCCMD = 1 << 10,  //工控机控制      58
        StopOutToAGV = 1 << 11, //中断出口到小车     59
        ViceReset = 1 << 12,  //从机复位             60
    }


    public delegate void ViceSyncHandler(object sender, byte[] args, eVulcanizeViceState state);

    /// <summary>
    /// 硫化道-副
    /// </summary>
    public class VulcanizeViceDevice : PlcDeviceBase
    {
        //副同步到主
        public event ViceSyncHandler OnViceSync;

        protected eVulcanizeViceOption _option = default(eVulcanizeViceOption);

        protected eVulcanizeViceState _status;
        public eVulcanizeViceState Status
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
        public VulcanizeViceDevice(IPort port, ISerialize serialize) : base(port, serialize)
        {
            try
            {
                _port.Write(_serialize.Serialize(new ReadRandomCommand(eElementCode.M, 3 * 16)))
                 .Read(out byte[] result);
                var res = _serialize.Deserialize<ReadRandomResult>(result);
                if (res.Code == ePlcResultCode.OK)
                    _option = (eVulcanizeViceOption)res.WordData;
            }
            catch (Exception ex)
            {
                Logger.ErrorInfo("VulcanizeViceDevice", ex);
            }
            _isOnline = true;
            IPCCMD(true);
            Update();
        }
        protected async void Update()
        {
            while (true)
            {
                var status = Task.Run(() =>
                {
                    byte[] result;
                      eVulcanizeViceState newState = default(eVulcanizeViceState);
                    lock (_port)
                    {
                        _port.Write(_serialize.Serialize(new ReadRandomCommand(eElementCode.M, 2 * 16)))
                             .Read(out result);
                        if (null != result)
                        {
                            var res = _serialize.Deserialize<ReadRandomResult>(result);
                            if (res.Code == ePlcResultCode.OK)
                                newState = (eVulcanizeViceState)res.WordData;
                        }
                    }
                  
                    //Sync
                    lock (_port)
                    {
                        _port.Write(_serialize.Serialize(new ReadCommand(eElementCode.D, 50, 24)))
                             .Read(out result);
                    }
                    var data = _serialize.Deserialize<PlcResultBase>(result);
                        if (ePlcResultCode.OK == data.Code)
                        {
                        try
                        {
                            OnViceSync?.Invoke(this, result.Skip(11).ToArray(), newState);
                        }
                        catch(Exception ex)
                        {
                            Logger.ErrorInfo("副同步主调用", ex);
                        }
                    }
                    Thread.Sleep(100);
                    return newState;
                });
                Status = await status;
            }
        }

        public void Sync(object sender, eVulcanizeState state)
        {
            lock (_port)
            {
                //冷却到出口
                _option = (Bit.Tst(state, eVulcanizeState.CoolerToExit) ? Bit.Set(_option, eVulcanizeViceOption.CoolerToExit) : Bit.Clr(_option, eVulcanizeViceOption.CoolerToExit));

                //硫化门升
                _option = (Bit.Tst(state, eVulcanizeState.VulcanizationDoorUp) ? Bit.Set(_option, eVulcanizeViceOption.VulcanizationDoorUp) : Bit.Clr(_option, eVulcanizeViceOption.VulcanizationDoorUp));

                //冷却门升
                _option = (Bit.Tst(state, eVulcanizeState.CoolerDoorUp) ? Bit.Set(_option, eVulcanizeViceOption.CoolerDoorUp) : Bit.Clr(_option, eVulcanizeViceOption.CoolerDoorUp));

                //硫化到冷却
                _option = (Bit.Tst(state, eVulcanizeState.VulcanizationToCooler) ? Bit.Set(_option, eVulcanizeViceOption.CoolerReady) : Bit.Clr(_option, eVulcanizeViceOption.CoolerReady));

                //硫化门降
                _option = (Bit.Tst(state, eVulcanizeState.VulcanizationDoorDown) ? Bit.Set(_option, eVulcanizeViceOption.VulcanizationDoorDown) : Bit.Clr(_option, eVulcanizeViceOption.VulcanizationDoorDown));

                //冷却门降
                _option = (Bit.Tst(state, eVulcanizeState.CoolerDoorDown) ? Bit.Set(_option, eVulcanizeViceOption.CoolerDoorDown) : Bit.Clr(_option, eVulcanizeViceOption.CoolerDoorDown));

                //手动冷却传送带动
                _option = (Bit.Tst(state, eVulcanizeState.HandOpertionCoolerTransmission) ? Bit.Set(_option, eVulcanizeViceOption.HandOpertionCoolerTransmission) : Bit.Clr(_option, eVulcanizeViceOption.HandOpertionCoolerTransmission));

                //出口到小车
                _option = (Bit.Tst(state, eVulcanizeState.OutToAGV) ? Bit.Set(_option, eVulcanizeViceOption.OutToAGV) : Bit.Clr(_option, eVulcanizeViceOption.OutToAGV));

                //急停
                _option = (Bit.Tst(state, eVulcanizeState.Estop) ? Bit.Set(_option, eVulcanizeViceOption.EStop) : Bit.Clr(_option, eVulcanizeViceOption.EStop));

                //从机复位
                _option = (Bit.Tst(state, eVulcanizeState.ViceReset) ? Bit.Set(_option, eVulcanizeViceOption.ViceReset) : Bit.Clr(_option, eVulcanizeViceOption.ViceReset));

                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 3 * 16, (ushort)_option)));
                _port.Read(out byte[] result);
#if DEBUG
                var res = _serialize.Deserialize<WriteRandomResult>(result);
                Logger.LogInfo($"VulcanizeVice:Sync, code:{state.ToString()}");

                Logger.LogInfo($"VulcanizeVice:Sync, code:{res.Code.ToString()}");
#endif
            }
        }

        /// <summary>
        /// 硫化门升
        /// </summary>
        /// <returns></returns>
        public IDevice VulcanizationDoorUp(bool enable = true)
        {
            byte[] result;
            lock (_port)
            {
                _option = enable ? Bit.Set(_option, eVulcanizeViceOption.VulcanizationDoorUp) : Bit.Clr(_option, eVulcanizeViceOption.VulcanizationDoorUp);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 3 * 16, (ushort)_option)))
                   .Read(out result);
            }
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"VulcanizeVice:VulcanizationDoorUp, code:{res.Code.ToString()}");
#endif

            return this;
        }


        /// <summary>
        /// 冷却门升
        /// </summary>
        /// <returns></returns>
        public IDevice CoolerDoorUp(bool enable = true)
        {
            byte[] result;
            lock (_port)
            {
                _option = enable ? Bit.Set(_option, eVulcanizeViceOption.CoolerDoorUp) : Bit.Clr(_option, eVulcanizeViceOption.CoolerDoorUp);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 3 * 16, (ushort)_option)))
                   .Read(out result);
            }
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"VulcanizeVice:CoolerDoorUp, code:{res.Code.ToString()}");
#endif

            return this;

        }

        /// <summary>
        /// 出盘准备
        /// </summary>
        /// <returns></returns>
        public IDevice CoolerToExit(bool enable = true)
        {
            byte[] result;
            lock (_port)
            {
                _option = enable ? Bit.Set(_option, eVulcanizeViceOption.CoolerToExit) : Bit.Clr(_option, eVulcanizeViceOption.CoolerToExit);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M,3 * 16, (ushort)_option)))
                   .Read(out result);
            }
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"VulcanizeVice:CoolerToExit, code:{res.Code.ToString()}");
#endif

            return this;
        }



        /// <summary>
        /// 硫化门降
        /// </summary>
        /// <returns></returns>
        public IDevice VulcanizationDoorDown(bool enable = true)
        {
            byte[] result;
            lock (_port)
            {
                _option = enable ? Bit.Set(_option, eVulcanizeViceOption.VulcanizationDoorDown) : Bit.Clr(_option, eVulcanizeViceOption.VulcanizationDoorDown);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 3 * 16, (ushort)_option)))
                     .Read(out result);
            }
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"VulcanizeVice:VulcanizationDoorDown, code:{res.Code.ToString()}");
#endif

            return this;
        }


        /// <summary>
        /// 冷却门降
        /// </summary>
        /// <returns></returns>
        public IDevice CoolerDoorDown(bool enable = true)
        {
            byte[] result;
            lock (_port)
            {
                _option = enable ? Bit.Set(_option, eVulcanizeViceOption.CoolerDoorDown) : Bit.Clr(_option, eVulcanizeViceOption.CoolerDoorDown);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 3 * 16, (ushort)_option)))
                     .Read(out result);
            }
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"VulcanizeVice:CoolerDoorDown, code:{res.Code.ToString()}");
#endif

            return this;

        }

        /// <summary>
        /// 手动冷却传送带动
        /// </summary>
        /// <returns></returns>
        public IDevice HandOpertionCoolerTransmission(bool enable = true)
        {
            byte[] result;
            lock (_port)
            {
                _option = enable ? Bit.Set(_option, eVulcanizeViceOption.HandOpertionCoolerTransmission) : Bit.Clr(_option, eVulcanizeViceOption.HandOpertionCoolerTransmission);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 3 * 16, (ushort)_option)))
                     .Read(out result);
            }
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"VulcanizeVice:HandOpertionCoolerTransmission, code:{res.Code.ToString()}");
#endif

            return this;
        }
        /// <summary>
        /// 出口到小车
        /// </summary>
        /// <returns></returns>
        public IDevice OutToAGV(bool enable = true)
        {
            byte[] result;
            lock (_port)
            {
                _option = enable ? Bit.Set(_option, eVulcanizeViceOption.OutToAGV) : Bit.Clr(_option, eVulcanizeViceOption.OutToAGV);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 3 * 16, (ushort)_option)))
                     .Read(out result);
            }
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"VulcanizeVice:OutToAGV, code:{res.Code.ToString()}");
#endif

            return this;
        }



        /// <summary>
        /// 硫化到冷却
        /// </summary>
        /// <returns></returns>
        public IDevice CoolerReady(bool enable = true)
        {
            byte[] result;
            lock (_port)
            {
                _option = enable ? Bit.Set(_option, eVulcanizeViceOption.CoolerReady) : Bit.Clr(_option, eVulcanizeViceOption.CoolerReady);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 3 * 16, (ushort)_option)))
                     .Read(out result);
            }
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"VulcanizeVice:CoolerReady, code:{res.Code.ToString()}");
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
                _option = Bit.Clr(_option, eVulcanizeViceOption.IPCCMD);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 3 * 16, (ushort)_option)));
                _port.Read(out result);
            }

#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"VulcanizeVice:IPCCMD, code:{res.Code.ToString()}");
#endif

            return this;
        }

        /// <summary>
        /// 中断出口到小车
        /// </summary>
        /// <param name="enable"></param>
        /// <returns></returns>
        public IDevice StopOutToAGV(bool enable = true)
        {
            byte[] result;
            lock (_port)
            {
                _option = enable ? Bit.Set(_option, eVulcanizeViceOption.StopOutToAGV) : Bit.Clr(_option, eVulcanizeViceOption.StopOutToAGV);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 3 * 16, (ushort)_option)))
                     .Read(out result);
            }
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"VulcanizeVice:StopOutToAGV, code:{res.Code.ToString()}");
#endif
            return this;
        }


        /// <summary>
        /// 从机复位
        /// </summary>
        /// <param name="enable"></param>
        /// <returns></returns>
        public IDevice ViceReset(bool enable = true)
        {
            byte[] result;
            lock (_port)
            {
                _option = enable ? Bit.Set(_option, eVulcanizeViceOption.ViceReset) : Bit.Clr(_option, eVulcanizeViceOption.ViceReset);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 3 * 16, (ushort)_option)))
                     .Read(out result);
            }
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"VulcanizeVice:ViceReset, code:{res.Code.ToString()}");
#endif
            return this;
        }

        /// <summary>
        /// 急停
        /// </summary>
        /// <returns></returns>
        public IDevice EStop(bool enable = true)
        {
            byte[] result;
            lock (_port)
            {
                _option = enable ? Bit.Set(_option, eVulcanizeViceOption.EStop) : Bit.Clr(_option, eVulcanizeViceOption.EStop);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 3 * 16, (ushort)_option)))
                     .Read(out result);
            }
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"VulcanizeVice:EStop, code:{res.Code.ToString()}");
#endif

            return this;
        }

        public override void Reset(bool force = false)
        {
            byte[] result;
            lock (_port)
            {
                _option = force ? Bit.Set(_option, eVulcanizeViceOption.Reset) : Bit.Clr(_option, eVulcanizeViceOption.Reset);
                _port.Write(_serialize.Serialize(new WriteRandomCommand(eElementCode.M, 3 * 16, (ushort)_option)))
                     .Read(out result);
            }
#if DEBUG
            var res = _serialize.Deserialize<WriteRandomResult>(result);
            Logger.LogInfo($"VulcanizeVice:Reset, code:{res.Code.ToString()}");
#endif
        }
    }
}