using System;
using System.Threading;
using System.Threading.Tasks;
using HuiJinYun.Domain.Entity.AGV;
using HuiJinYun.Domain.Infrastructure.Common;
using HuiJinYun.Domain.Infrastructure.Port;
using HuiJinYun.Domain.Log;
using HuiJinYun.Domain.Enum;
using HuiJinYun.Domain.Infrastructure.Watcher;

namespace HuiJinYun.Domain.Entity.Device
{
    public delegate void SyncAGVHandler(object sender, SyncU3D sync);

    public class UWantAGV<TState, TPosition> : IAGV<TState, TPosition>
    {
        protected IPort _port;
        protected ISerialize _serialize;
        protected byte _AGVNo;
        protected volatile dynamic _position = default(TPosition); //  volatile dynamic   TPosition
        protected TState _state;
        public static event SyncAGVHandler OnSync;

        protected const int BUFFER_SIZE = 126;
        protected byte[] _buffer = new byte[BUFFER_SIZE];
        protected int _rOffset = 0;
        protected int _wOffset = 0;
        protected int _length = 0;

        public  TPosition Position
        {
            get
            {
                return _position;


            }
            protected set
            {
                if(!_position.Equals(value))
                {
                    _position = value;
                    StateChanged(new DeviceStateChangeEventArgs(_position));
                    if (value != _position)
                    {
                        Logger.LogInfo($"AGV  value {value}:changedState, code:{_position}");
                    }
                }
            }
        }

        public TState State
        {
            get
            {
                return _state;
            }
            set
            {
                if (!_state.Equals(value))
                {
                    _state = value;
                    StateChanged(new DeviceStateChangeEventArgs(_state));
                }
            }
        }
        
        public int Number
        {
            get { return _AGVNo; }
            set { }
        }

        #region Notify
        public event NotifyEventHandler OnNotify;
        protected void StateChanged(DeviceStateChangeEventArgs args) => OnNotify?.Invoke(this, args);
        #endregion

        public UWantAGV(IPort port, ISerialize serialize, object AGVNo)
        {
            port.OnReceived += Port_OnReceived;
            _port = port;
            _serialize = serialize;
            _AGVNo = byte.Parse(AGVNo.ToString());
            /*byte[] result = null;
            try
            {
                lock (_port)
                {
                    _port.Write(_serialize.Serialize<OutputCommand>(new OutputCommand(_AGVNo, eSwitchNumber.StatusActiveUpload, AGV.eSwitchStates.Shut)));
                    Thread.Sleep(300);
                    _port.Write(_serialize.Serialize<OutputCommand>(new OutputCommand(_AGVNo, eSwitchNumber.NodeNumberActiveUpload, AGV.eSwitchStates.Shut)));
                    Thread.Sleep(300);
                    _port.Write(_serialize.Serialize<OutputCommand>(new OutputCommand(_AGVNo, eSwitchNumber.DispatchingHeartbeatSwitch, AGV.eSwitchStates.Shut)));
                    Thread.Sleep(300);
                    _port.Read(out result, 0, 20 * 3);
                }
            }
            catch(Exception ex)
            {
                Logger.ErrorInfo("UWantAGV", ex);
            }
#if DEBUG
            try
            {
                var code = BitConverter.ToString(result).Replace('-', ' ');
                Logger.LogInfo($"AGV{_AGVNo}:Initial, code:{code}");
            }
            catch { };
#endif
            Update();*/
        }

        private void Port_OnReceived(object sender, PortReceivedEventArgs args)
        {
            if (args.Data.Length > BUFFER_SIZE)
            {
                _wOffset = 0;
                _rOffset = 0;
                _length = 0;
                return;
            }
            if (BUFFER_SIZE >= _wOffset + args.Length)
            {
                Array.Copy(args.Data, 0, _buffer, _wOffset % BUFFER_SIZE, args.Length);
            }
            else
            {
                Array.Copy(args.Data, 0, _buffer, _wOffset % BUFFER_SIZE, BUFFER_SIZE - _wOffset);
                Array.Copy(args.Data, BUFFER_SIZE - _wOffset, _buffer, 0, (args.Length - (BUFFER_SIZE - _wOffset)) % BUFFER_SIZE);
            }
            _wOffset = (_wOffset + _length) % BUFFER_SIZE;
            _length += args.Length;
            if (BUFFER_SIZE < _length)
            {
                _rOffset = _wOffset;
                _length = BUFFER_SIZE;
            }

            byte[] d;
            int startOffset = -1;
            int endOffset = -1;
            for(int o = _rOffset, l = _length; (--l) > 0; o = (++o) % BUFFER_SIZE)
            {
                if ((byte)(0x80 + _AGVNo) == _buffer[o]) startOffset = o;
                else if ((byte)(0xFF - (0x80 + _AGVNo)) == _buffer[o])
                {
                    if (0 > startOffset) continue;

                    endOffset = (o + 1) % BUFFER_SIZE;
                    if (startOffset < endOffset)
                    {
                        d = new byte[endOffset - startOffset];
                        Array.Copy(_buffer, startOffset, d, 0, d.Length);
                    }
                    else
                    {
                        d = new byte[(BUFFER_SIZE - startOffset + endOffset)];
                        Array.Copy(_buffer, startOffset, d, 0, BUFFER_SIZE - startOffset);
                        Array.Copy(_buffer, 0, d, BUFFER_SIZE - startOffset, endOffset);
                    }
                    _length -= _rOffset < endOffset ? endOffset - _rOffset : BUFFER_SIZE - _rOffset + endOffset;
                    _rOffset = endOffset;
                    startOffset = -1;
                    endOffset = -1;

                    try
                    {
                        var code = BitConverter.ToString(d).Replace('-', ' ');
                        Logger.LogInfo($"AGV{_AGVNo}:Update, code:{code}");
                    }
                    catch(Exception ex)
                    {
                        Logger.ErrorInfo($"AGV{_AGVNo}:Update, code:{BitConverter.ToString(d)}", ex);
                    }
                    //TODO:d
                    try
                    {
                        TPosition pos = default(TPosition);
                        TState state = default(TState);
                        var res = _serialize.Deserialize<StateResult>(d);
                        if (res.UPHead == (0x80 + _AGVNo) && eAgvResultWord.State == res.CommandWord)
                        {
                            Position = (TPosition)System.Enum.ToObject(typeof(TPosition), res.NodeNumber);
                            State = (TState)System.Enum.ToObject(typeof(TState), res.State);
                        }
                    }
                    catch
                    {
                        var code = BitConverter.ToString(d).Replace('-', ' '); //args.Data
                        Logger.LogInfo($"AGV{_AGVNo}:OnReceived, code:{code}");
                    }
                }
            }
        }

        /*
        protected async void Update()
        {
            while (true)
            {
                var status = Task.Run(() =>
                {
                    bool bOk = false;
                    byte[] result = null;
                    TPosition pos = default(TPosition);
                    TState state = default(TState);
                    lock (_port)
                    {
                        _port.Write(_serialize.Serialize(new StateCommand(_AGVNo)));
                        Thread.Sleep(300);
                        // _port.Read(out result, 0, 20);

                        _port.Read(out byte[] results);
                        int i = 0;
                        while (true)
                        {
                            if ((byte)results[i] == (byte)(0x8 + _AGVNo) && (byte)results[i + 20] == (byte)(0xFF - 0x8 + _AGVNo))
                            {
                                _port.Read(out result, i, 20);
                            }
                        }
                    }
 
                        //临时日志 2018113
#if DEBUG
                        try
                        {
                            try
                            {
                                var code = BitConverter.ToString(result).Replace('-', ' ');
                                Logger.LogInfo($"AGV{_AGVNo}:Update, code:{code}");
                            }
                            catch
                            {
                                //var code = BitConverter.ToString(result).Replace('-', ' ');
                                Logger.LogInfo($"AGV{_AGVNo}:Update, code:{BitConverter.ToString(result)}");
                            }
                        }
                        catch { };
#endif

                    if (null != result)
                    {
                        if (result.Length > 1 && result.Length < 21)
                        {
                            if ((0x80 + _AGVNo) == result[0]) //(0x80 + _AGVNo) != result[0] || 0xFF == result[1]
                            {
                                try
                                {
                                    var res = _serialize.Deserialize<StateResult>(result);
                                    if (res.UPHead == (0x80 + _AGVNo) && eAgvResultWord.State == res.CommandWord)
                                    {
                                        pos = (TPosition)System.Enum.ToObject(typeof(TPosition), res.NodeNumber);
                                        state = (TState)System.Enum.ToObject(typeof(TState), res.State);
                                        bOk = true;
                                    }
                                }
                                catch(Exception ex)
                                {
                                    Logger.ErrorInfo("AGV result解析出错", ex);
                                }
                            }
                            else if (result.Length > 19 && result[19] == (0x80 + _AGVNo))
                            {
                                byte[] newresult = new byte[21];
                                byte[] outdata = new byte[20];

                                try
                                {
                                    result.CopyTo(newresult, 1);
                                    newresult[0] = result[19];
                                    Array.Copy(newresult, 0, outdata, 0, 20);
                                }
                                catch (Exception ex)
                                {
                                    Logger.ErrorInfo("AGV result 补包", ex);
                                }

                                var res = _serialize.Deserialize<StateResult>(outdata);
                                if (res.UPHead == (0x80 + _AGVNo) && eAgvResultWord.State == res.CommandWord)
                                {
                                    pos = (TPosition)System.Enum.ToObject(typeof(TPosition), res.NodeNumber);
                                    state = (TState)System.Enum.ToObject(typeof(TState), res.State);
                                    bOk = true;
                                }
                            }
                            else
                            {
#if DEBUG
                                var res = _serialize.Deserialize<ErrorReportingResult>(result);
                                var code = BitConverter.ToString(result).Replace('-', ' ');
                                Logger.LogInfo($"AGV{_AGVNo}:update error, code:{code}");
#endif

                            }
                        }
                        else
                        {
#if DEBUG
                            var res = _serialize.Deserialize<ErrorReportingResult>(result);
                            var code = BitConverter.ToString(result).Replace('-', ' ');
                            Logger.LogInfo($"AGV{_AGVNo}:update error, code:{code}");
#endif
                        }

                    }
                    else
                    {
                        try
                        {
                            if ((0x80 + _AGVNo) != result[0] || 0xFF == result[1])
                            {
#if DEBUG
                                var res = _serialize.Deserialize<ErrorReportingResult>(result);
                                var code = BitConverter.ToString(result).Replace('-', ' ');
                                Logger.LogInfo($"AGV{_AGVNo}:update error, code:{code}");
#endif
                            }
                        }
                        catch { }
                    }
                    Thread.Sleep(300);
                    return !bOk ? null : new { pos, state };
                });
                var s = await status;
                if (null != s)
                {
                    Position = s.pos;
                    State = s.state;
                }
            }
        }
        */

        public IAGV<TState, TPosition> Goto(TPosition position, int mode = 0)
        {
            byte[] result = null;

            lock (_port)
            {
                switch ((int)(eNodeNumber)System.Enum.ToObject(typeof(eNodeNumber), position))
                {
                    case 1:
                        _port.Write(_serialize.Serialize(new MotionControlCommand(_AGVNo, eMoveDirection.FrontPatrol, eSpeed.Speed2, eLogicalDirection.LogicalGo, 2)));
                        Thread.Sleep(300);
                        _port.Read(out result, 0, 20);
                        break;
                    case 2:
                        _port.Write(_serialize.Serialize(new MotionControlCommand(_AGVNo, eMoveDirection.FrontPatrol, eSpeed.Speed1, eLogicalDirection.LogicalGo, 2)));
                        Thread.Sleep(300);
                        _port.Read(out result, 0, 20);
                        break;
                    case 3:
                        _port.Write(_serialize.Serialize(new MotionControlCommand(_AGVNo, eMoveDirection.FrontPatrol, eSpeed.Speed1, eLogicalDirection.LogicalGo, 2)));
                        Thread.Sleep(300);
                        _port.Read(out result, 0, 20);
                        break;
                    case 4:
                        _port.Write(_serialize.Serialize(new MotionControlCommand(_AGVNo, eMoveDirection.FrontPatrol, eSpeed.Speed1, eLogicalDirection.LogicalGo, 2)));
                        Thread.Sleep(300);
                        _port.Read(out result, 0, 20);
                        break;
                    case 5:
                        _port.Write(_serialize.Serialize(new MotionControlCommand(_AGVNo, eMoveDirection.FrontPatrol, eSpeed.Speed1, eLogicalDirection.LogicalGo, 2)));
                        Thread.Sleep(300);
                        _port.Read(out result, 0, 20);
                        break;
                }
            }
#if DEBUG
            try
            {
                var pos = System.Enum.GetName(typeof(TPosition), position);
                var res = BitConverter.ToString(result).Replace('-', ' ');
                Logger.LogInfo($"AGV{_AGVNo}:goto {pos}@{mode}, res:{res}");
            }
            catch
            {
            }
#endif



            //_port.Write(_serialize.Serialize(new MotionControlCommand(_AGVNo, eMoveDirection.FrontPatrol, (eSpeed)System.Enum.ToObject(typeof(eSpeed), mode), eLogicalDirection.LogicalGo, 2)));
            //Thread.Sleep(300);
            //_port.Read(out result, 0, 20);
            SyncU3D sync = null;
            try
            {
                switch (_AGVNo)
                {

                    case 3:
                        switch ((int)(eNodeNumber)System.Enum.ToObject(typeof(eNodeNumber), position))
                        {
                            case 1:
                                sync = new SyncU3D() { type = eSyncU3D.AGV, number = 0, Position = 1, Operate = true };
                                OnSync?.Invoke(this, sync);
                                break;
                            case 2:
                                sync = new SyncU3D() { type = eSyncU3D.AGV, number = 0, Position = 1, Operate = true };
                                OnSync?.Invoke(this, sync);
                                break;
                            case 3:
                                sync = new SyncU3D() { type = eSyncU3D.AGV, number = 0, Position = 2, Operate = true };
                                OnSync?.Invoke(this, sync);
                                break;
                            case 4:
                                sync = new SyncU3D() { type = eSyncU3D.AGV, number = 0, Position = 3, Operate = true };
                                OnSync?.Invoke(this, sync);
                                break;
                            case 5:
                                sync = new SyncU3D() { type = eSyncU3D.AGV, number = 0, Position = 4, Operate = true };
                                OnSync?.Invoke(this, sync);
                                break;
                        }

                        break;
                    case 4:
                        switch ((int)(eNodeNumber)System.Enum.ToObject(typeof(eNodeNumber), position))
                        {
                            case 1:
                                sync = new SyncU3D() { type = eSyncU3D.AGV, number = 1, Position = 1, Operate = true };
                                OnSync?.Invoke(this, sync);
                                break;
                            case 2:
                                sync = new SyncU3D() { type = eSyncU3D.AGV, number = 1, Position = 1, Operate = true };
                                OnSync?.Invoke(this, sync);
                                break;
                            case 3:
                                sync = new SyncU3D() { type = eSyncU3D.AGV, number = 1, Position = 2, Operate = true };
                                OnSync?.Invoke(this, sync);
                                break;
                            case 4:
                                sync = new SyncU3D() { type = eSyncU3D.AGV, number = 1, Position = 3, Operate = true };
                                OnSync?.Invoke(this, sync);
                                break;
                            case 5:
                                sync = new SyncU3D() { type = eSyncU3D.AGV, number = 1, Position = 4, Operate = true };
                                OnSync?.Invoke(this, sync);
                                break;
                        }
                        break;
                    case 6:
                        switch ((int)(eNodeNumber)System.Enum.ToObject(typeof(eNodeNumber), position))
                        {
                            case 1:
                                sync = new SyncU3D() { type = eSyncU3D.AGV, number = 2, Position = 1, Operate = true };
                                OnSync?.Invoke(this, sync);
                                break;
                            case 2:
                                sync = new SyncU3D() { type = eSyncU3D.AGV, number = 2, Position = 1, Operate = true };
                                OnSync?.Invoke(this, sync);
                                break;
                            case 3:
                                sync = new SyncU3D() { type = eSyncU3D.AGV, number = 2, Position = 2, Operate = true };
                                OnSync?.Invoke(this, sync);
                                break;
                            case 4:
                                sync = new SyncU3D() { type = eSyncU3D.AGV, number = 2, Position = 3, Operate = true };
                                OnSync?.Invoke(this, sync);
                                break;
                            case 5:
                                sync = new SyncU3D() { type = eSyncU3D.AGV, number = 2, Position = 4, Operate = true };
                                OnSync?.Invoke(this, sync);
                                break;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorInfo("Goto", ex);

            }

            //Thread.Sleep(300);
            //  _port.Read(out result, 0, 20 * 3);

            return this;
        }

        public IAGV<TState, TPosition> Export(TPosition position, int port, bool enable)
        {
            try
            {
                byte[] result;
                switch (port)
                {
                    case 1:
                        _port.Write(_serialize.Serialize<OutputCommand>(new OutputCommand(_AGVNo, eSwitchNumber.SpareOutput_1, enable ? AGV.eSwitchStates.Open : AGV.eSwitchStates.Shut)));
                        Thread.Sleep(300);
                        _port.Read(out result);
                        break;
                    case 2:
                        _port.Write(_serialize.Serialize<OutputCommand>(new OutputCommand(_AGVNo, eSwitchNumber.SpareOutput_2, enable ? AGV.eSwitchStates.Open : AGV.eSwitchStates.Shut)));
                        Thread.Sleep(300);
                        _port.Read(out result);
                        break;
                    default:
                        result = null;
                        break;
                }
#if DEBUG
                var pos = System.Enum.GetName(typeof(TPosition), position);
                var res = BitConverter.ToString(result).Replace('-', ' ');
                Logger.LogInfo($"AGV{_AGVNo}:Export {pos}@{enable}, res:{res}");
#endif

            }
            catch (Exception ex)
            {
                Logger.ErrorInfo("Export", ex);
            }
            return this;
        }

        /// <summary>
        /// 检测盘子到位
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public IAGV<TState, TPosition> CheckTray(TPosition position)
        {
            byte[] result;

            try
            {
                lock(_port)
                {
                    _port.Write(_serialize.Serialize(new trafficControlCommand(_AGVNo, (eNodeNumber)System.Enum.ToObject(typeof(eNodeNumber), position), eAction.Check, 0x21, 0x00)));
                    Thread.Sleep(300);
                    _port.Read(out result, 0, 20 * 3);
                }
#if DEBUG
                var pos = System.Enum.GetName(typeof(TPosition), position);
                var res = BitConverter.ToString(result).Replace('-', ' ');
                Logger.LogInfo($"AGV{_AGVNo}:CheckTray {pos}, res:{res}");
#endif
            }
            catch (Exception ex)
            {
                Logger.ErrorInfo("CheckTray", ex);
            }

            return this;
        }

        public IAGV<TState, TPosition> Stop(int mode = 0)
        {
            try
            {
                lock (_port)
                {
                    _port.Write(_serialize.Serialize(new trafficControlCommand(_AGVNo, eNodeNumber.Node_1, eAction.Estop, 0x00, 0x00)));
                    Thread.Sleep(300);
                    _port.Read(out byte[] result);
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorInfo("Stop", ex);
            }
            return this;
        }
    }
}
