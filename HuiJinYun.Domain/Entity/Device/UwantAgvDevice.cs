using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuiJinYun.Domain.Infrastructure.Common;
using HuiJinYun.Domain.Infrastructure.Port;
using HuiJinYun.Domain.Entity.AGV;
using HuiJinYun.Domain.Entity.PLC;
using HuiJinYun.Domain.Log;
using System.Threading;

namespace HuiJinYun.Domain.Entity.Device
{
    public class UwantAgvDevice : UwantAgvDeviceBase
    {
        public UwantAgvDevice(IPort port, ISerialize serialize) :
            base(port, serialize)
        {
        }
        /// <summary>
        /// 获取AGV状态信息    ok
        /// </summary>
        /// <returns></returns>
        public IDevice GetState()
        {
            byte[] result; 
            StateCommand cmd = new StateCommand(0x02);
            _port.Write(_serialize.Serialize<StateCommand>(cmd))
                .Read(out result);
            if (null != result)
            {
                var res = _serialize.Deserialize<StateResult>(result);
            }

            return this;
        }

        /// <summary>
        /// 运动控制      ok 
        /// </summary>
        /// <returns></returns>
        public IDevice SetMotionControl()
        {
            byte[] result;
            MotionControlCommand cmd = new MotionControlCommand(0x02, eMoveDirection.TurnRight, eSpeed.Speed2, eLogicalDirection.LogicalGo,2);
            _port.Write(_serialize.Serialize<MotionControlCommand>(cmd))
                .Read(out result);
            if (null != result)
            {
                if (result.Length > 2)
                {
                    if (0xFF == result[1])
                    {
                        var res = _serialize.Deserialize<ErrorReportingResult>(result);
                    }
                    else
                    {
                        var res = _serialize.Deserialize<MotionControlResult>(result);
                    }
                }
            }
            return this;
        }


        /// <summary>
        /// 路线切换     ok 
        /// </summary>
        /// <returns></returns>
        public IDevice SetRouteSwitchCommand()
        {
            byte[] result;
            RouteSwitchCommand cmd = new RouteSwitchCommand(0x02, 2, 1);
            _port.Write(_serialize.Serialize<RouteSwitchCommand>(cmd))
                .Read(out result);
            if (null != result)
            {
                if (result.Length > 2)
                {
                    if (0xFF == result[1])
                    {
                        var res = _serialize.Deserialize<ErrorReportingResult>(result);
                    }
                    else
                    {
                        var res = _serialize.Deserialize<RouteSwitchResult>(result);
                    }
                }
            }
            return this;
        }


        /// <summary>
        /// 设置输出/开关状态(断电不保存)   ok 
        /// </summary>
        /// <returns></returns>
        public IDevice SetOutputCommand()
        {
            byte[] result;
            OutputCommand cmd = new OutputCommand(0x02, eSwitchNumber.AcoustoopticAlarm, AGV.eSwitchStates.Shut);
            _port.Write(_serialize.Serialize<OutputCommand>(cmd))
                .Read(out result);
            if (null != result)
            {
                if (result.Length > 2)
                {
                    if (0xFF == result[1])
                    {
                        var res = _serialize.Deserialize<ErrorReportingResult>(result);
                    }
                    else
                    {
                        var res = _serialize.Deserialize<OutputResult>(result);
                    }
                }
            }
            return this;
        }


        /// <summary>
        /// 实时交通控制 (节点动作设置，断电不保存)
        /// </summary>
        /// <returns></returns>
        public IDevice SettrafficControl()
        {
            byte[] result;
            MotionControlCommand cmd = new MotionControlCommand(0x02, eMoveDirection.FrontPatrol, eSpeed.Speed2, eLogicalDirection.LogicalGo, 2);
            _port.Write(_serialize.Serialize<MotionControlCommand>(cmd))
                .Read(out result);

            trafficControlCommand cmd1 = new trafficControlCommand(0x02, eNodeNumber.Undefined, eAction.Alarm,0x00,0x00);
            byte[] fgfg = _serialize.Serialize<trafficControlCommand>(cmd1);
            _port.Write(_serialize.Serialize<trafficControlCommand>(cmd1))
                .Read(out result);

            trafficControlCommand cmd2 = new trafficControlCommand(0x02, eNodeNumber.Node_3, eAction.Estop,0x00,0x00, eAction.BackOff,0x01,0);
            _port.Write(_serialize.Serialize<trafficControlCommand>(cmd2))
                .Read(out result);

            //trafficControlCommand cmd3 = new trafficControlCommand(0x02, eNodeNumber.Node_2, eAction.AppointStall, 2, 0);
            //_port.Write(_serialize.Serialize<trafficControlCommand>(cmd3))
            //    .Read(out result);
            return this;
        }

        /// <summary>
        ///节点编号 (获取/反馈)
        /// </summary>
        /// <returns></returns>
        public IDevice GetNodeNumber()
        {
            byte[] result;
            NodeNumberCommand cmd = new NodeNumberCommand(0x02);
            _port.Write(_serialize.Serialize<NodeNumberCommand>(cmd))
                .Read(out result);
            if (null != result)
            {
                if (result.Length > 2)
                {
                    if (0xFF == result[1])
                    {
                        var res = _serialize.Deserialize<ErrorReportingResult>(result);
                    }
                    else
                    {
                        var res = _serialize.Deserialize<NodeNumberResult>(result);
                    }
                }
            }
            return this;
        }
        /// <summary>
        /// 卡片直接执行
        /// </summary>
        /// <returns></returns>
        public IDevice SetCardXIP()
        {
            byte[] result;
            CardXIPCommand cmd = new CardXIPCommand(0x02,0x02);
            _port.Write(_serialize.Serialize<CardXIPCommand>(cmd))
                .Read(out result);
            if (null != result)
            {
                if (result.Length > 2)
                {
                    if (0xFF == result[1])
                    {
                        var res = _serialize.Deserialize<ErrorReportingResult>(result);
                    }
                    else
                    {
                        var res = _serialize.Deserialize<CardXIPResult>(result);
                    }
                }
            }
            return this;
        }


        /// <summary>
        ///输出
        /// </summary>
        /// <returns></returns>
        public IDevice SetOutput_Open(byte car)
        {
           
                lock (_port)
                {
                    byte[] result;
                    OutputCommand cmd = new OutputCommand(car, eSwitchNumber.SpareOutput_1, AGV.eSwitchStates.Open);
                    _port.Write(_serialize.Serialize<OutputCommand>(cmd))
                        .Read(out result);
                }
           
            return this;
        }

        /// <summary>
        ///输出
        /// </summary>
        /// <returns></returns>
        public IDevice SetOutput_fan_Open(byte car)
        {
           
                lock (_port)
                {
                    byte[] result;
                    OutputCommand cmd = new OutputCommand(car, eSwitchNumber.SpareOutput_2, AGV.eSwitchStates.Open);
                    _port.Write(_serialize.Serialize<OutputCommand>(cmd))
                        .Read(out result);
                }
            return this;
        }

        /// <summary>
        ///关闭
        /// </summary>
        /// <returns></returns>
        public IDevice SetOutput_close(byte car)
        {
         
                lock (_port)
                {
                    byte[] result;
                    OutputCommand cmd = new OutputCommand(car, eSwitchNumber.SpareOutput_1, AGV.eSwitchStates.Shut);
                    _port.Write(_serialize.Serialize<OutputCommand>(cmd))
                        .Read(out result);
                }
            return this;
        }

        /// <summary>
        ///关闭 反
        /// </summary>
        /// <returns></returns>
        public IDevice SetOutput_fan_close(byte car)
        {
           
                lock (_port)
                {
                    byte[] result;
                    OutputCommand cmd = new OutputCommand(car, eSwitchNumber.SpareOutput_2, AGV.eSwitchStates.Shut);
                    _port.Write(_serialize.Serialize<OutputCommand>(cmd))
                        .Read(out result);
                }
            return this;
        }


        public IDevice FrontPatrol(byte car,string Speed)
        {
            
                byte[] result = null;

                lock (_port)
                {
                    _port.Write(_serialize.Serialize(new MotionControlCommand(car, eMoveDirection.FrontPatrol, (eSpeed)System.Enum.ToObject(typeof(eSpeed), Int32.Parse(Speed)), eLogicalDirection.LogicalGo, 2)));
                    Thread.Sleep(300);
                    _port.Read(out result, 0, 20);
                }
            
            return this;
        }


        public IDevice SettrafficControlOutPut()
        {
            byte[] result;
            MotionControlCommand cmd = new MotionControlCommand(0x03, eMoveDirection.FrontPatrol, eSpeed.Speed2, eLogicalDirection.LogicalGo, 2);
            _port.Write(_serialize.Serialize<MotionControlCommand>(cmd))
                .Read(out result);
            return this;
        }



        /// <summary>
        /// 前进
        /// </summary>
        /// <returns></returns>
        public IDevice SetMotionControl_qianjing()
        {
            byte[] result;
            MotionControlCommand cmd = new MotionControlCommand(0x03, eMoveDirection.Advancing, eSpeed.Speed1, eLogicalDirection.LogicalGo, 2);
            _port.Write(_serialize.Serialize<MotionControlCommand>(cmd))
                .Read(out result);
            return this;
        }

        public IDevice SetMotionControl_houtui()
        {
            byte[] result;
            MotionControlCommand cmd = new MotionControlCommand(0x04, eMoveDirection.BackOff, eSpeed.Speed1, eLogicalDirection.LogicalGo, 2);
            _port.Write(_serialize.Serialize<MotionControlCommand>(cmd))
                .Read(out result);
            return this;
        }

        public IDevice SetMotionControl_left()
        {
            byte[] result;
            MotionControlCommand cmd = new MotionControlCommand(0x06, eMoveDirection.TurnLeft, eSpeed.Speed1, eLogicalDirection.LogicalGo, 2);
            _port.Write(_serialize.Serialize<MotionControlCommand>(cmd))
                .Read(out result);

            return this;
        }

        public IDevice SetMotionControl_right()
        {
            byte[] result;
            MotionControlCommand cmd = new MotionControlCommand(0x06, eMoveDirection.TurnRight, eSpeed.Speed1, eLogicalDirection.LogicalGo, 2);
            _port.Write(_serialize.Serialize<MotionControlCommand>(cmd))
                .Read(out result);

            return this;
        }

        public IDevice SetMotionControl_stop()
        {
            //byte[] result;
            //MotionControlCommand cmd = new MotionControlCommand(0x03, eMoveDirection.EStop, eSpeed.Speed0, eLogicalDirection.LogicalGo, 2);
            //_port.Write(_serialize.Serialize<MotionControlCommand>(cmd))
            //    .Read(out result);
            byte[] result;
            lock (_port)
            {
                _port.Write(_serialize.Serialize(new MotionControlCommand(4, eMoveDirection.FrontPatrol, eSpeed.Speed1, eLogicalDirection.LogicalGo, 2)));
                    Thread.Sleep(300);
                _port.Read(out result);
                var res3uy = _serialize.Deserialize<ErrorReportingResult>(result);
                Thread.Sleep(300);
                _port.Write(_serialize.Serialize(new trafficControlCommand(4, eNodeNumber.ClearNode)));
                     _port.Read(out result ,0, 20);
                var res2 = _serialize.Deserialize<ErrorReportingResult>(result);
                Thread.Sleep(150);
                _port.Write(_serialize.Serialize(new trafficControlCommand(6, eNodeNumber.Node_1, eAction.Stop, 0x01, 0x20)));
                //Thread.Sleep(150);
                _port.Write(_serialize.Serialize(new trafficControlCommand(6, eNodeNumber.Node_2, eAction.Check, 0x15, 0)))
                    .Read(out result, 0, 20);
                Thread.Sleep(300);
                _port.Write(_serialize.Serialize(new trafficControlCommand(4, eNodeNumber.Node_2, eAction.Alarm, 0x01, 0x05)));
                   Thread.Sleep(300); _port.Read(out result, 0, 20);
                var res3 = _serialize.Deserialize<ErrorReportingResult>(result);

                //_port.Write(_serialize.Serialize(new trafficControlCommand(6, eNodeNumber.Node_1, eAction.Check, 0x21, 0x00)));
                //Thread.Sleep(150);
                //_port.Write(_serialize.Serialize(new trafficControlCommand(6, eNodeNumber.Node_1, eAction.Output, 0x10, 0x00)));
                //Thread.Sleep(150);

                //Thread.Sleep(150);
                //_port.Read(out result, 0, 20 * 3);
            }
            //var res = _serialize.Deserialize<ErrorReportingResult>(result);

            return this;
        }

        /// <summary>
        /// 输入状态监测
        /// </summary>
        /// <returns></returns>

        public IDevice SetMonitor()
        {

            byte[] result;
            OutputCommand cmd = new OutputCommand(0x04, eSwitchNumber.SpareOutput_1, AGV.eSwitchStates.Open);
            _port.Write(_serialize.Serialize<OutputCommand>(cmd))
                .Read(out result);
            bool isopen = true;
            while(isopen)
            {
                byte[] resultStue;
                StateCommand cmd1 = new StateCommand(0x04);
                _port.Write(_serialize.Serialize<StateCommand>(cmd1))
                    .Read(out resultStue);
                Logger.LogInfo(resultStue.ToString());

                if (null != resultStue)
                {
                    byte[] resultStuestop;
                    var res = _serialize.Deserialize<StateResult>(resultStue);
                    Logger.LogInfo(res.State.ToString());
                    switch (res.State)
                    {
                        case eAGVState.BackupOff:
                            {
                                OutputCommand cmd2 = new OutputCommand(0x04, eSwitchNumber.SpareOutput_1, AGV.eSwitchStates.Shut);
                                _port.Write(_serialize.Serialize<OutputCommand>(cmd2))
                                    .Read(out resultStuestop);
                                Logger.LogInfo("BackupOff");
                                isopen = false;
                            }
                            break;
                        case eAGVState.BackupFPatrol: {
                                OutputCommand cmd2 = new OutputCommand(0x04, eSwitchNumber.SpareOutput_1, AGV.eSwitchStates.Shut);
                                _port.Write(_serialize.Serialize<OutputCommand>(cmd2))
                                    .Read(out resultStuestop);
                                Logger.LogInfo("BackupFPatrol");
                                isopen = false;
                            }
                            break;
                        case eAGVState.BackupBPatrol: {
                                OutputCommand cmd2 = new OutputCommand(0x04, eSwitchNumber.SpareOutput_1, AGV.eSwitchStates.Shut);
                                _port.Write(_serialize.Serialize<OutputCommand>(cmd2))
                                    .Read(out resultStuestop);
                                Logger.LogInfo("BackupBPatrol");
                                isopen = false;
                            }
                            break;
                    }
                }
                Thread.Sleep(5000);
            }

            return this;
        }

        public IDevice GoTo(int code)
        {
            byte [] result;
            switch (code)
            {
                case 0:
                    OutputCommand cmdOpen = new OutputCommand(0x03, eSwitchNumber.SpareOutput_1, AGV.eSwitchStates.Open);
                    _port.Write(_serialize.Serialize<OutputCommand>(cmdOpen))
                        .Read(out result);
                    break;
                case 1:
                    OutputCommand cmdStop_2 = new OutputCommand(0x03, eSwitchNumber.SpareOutput_1, AGV.eSwitchStates.Shut);
                    _port.Write(_serialize.Serialize<OutputCommand>(cmdStop_2))
                        .Read(out result);

                    break;
                case 2:
                  
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
            return this;
        }

        public IDevice NodesTate(out int data)
        {
            data = 0;
            byte[] result;
            StateCommand cmd = new StateCommand(4);
            lock (this)
            {
                lock (this)
                {
                    _port.Write(_serialize.Serialize<StateCommand>(cmd))
                        .Read(out result);
                }
            }
            if (null != result)
            {
                if (result.Length > 2)
                {
                    if (0xFF == result[1])
                    {
                        var res = _serialize.Deserialize<ErrorReportingResult>(result);
                        Logger.LogInfo("节点号bug" + "------" + res.ErrorCode.ToString());
                       
                    }
                    else
                    {
                        var res = _serialize.Deserialize<StateResult>(result);
                        data = res.NodeNumber;
                        Logger.LogInfo("节点号" + "------" + res.NodeNumber.ToString());
                    }
                }
            }
            Thread.Sleep(100);
            return this;
        }


    }
}
