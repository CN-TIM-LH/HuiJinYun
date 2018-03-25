using HuiJinYun.Domain.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.AGV
{
    public enum eAction : byte
    {
        /// <summary>
        /// 检测
        /// </summary>
        Check = 0x00,
        /// <summary>
        /// 前进
        /// </summary>
        Advancing = 0x01,
        /// <summary>
        /// 后退
        /// </summary>
        BackOff = 0x02,
        /// <summary>
        /// 左转
        /// </summary>
        TurnLeft = 0x03,
        /// <summary>
        /// 右转
        /// </summary>
        TurnRight = 0x04,
        /// <summary>
        /// 前巡
        /// </summary>
        FrontPatrol = 0x05,
        /// <summary>
        /// 后巡
        /// 参数1：运行速度：1-10 档
        /// 参数2：运行时间：单位秒。 填0 则无限运行。
        /// </summary>
        RearPatrol = 0x06,                 
        /// <summary>
        /// 直行（分叉路口）
        /// </summary>
        StraightForkJunction = 0x07,       
        /// <summary>
        /// 左岔（分叉路口）
        /// </summary>
        LeftForkJunction = 0x08,
        /// <summary>
        /// 右岔（分叉路口）
        /// </summary>
        RightForkJunction = 0x09,
        /// <summary>
        /// 停止/延时
        /// </summary>
        Stop = 0x0A,
        /// <summary>
        /// 档位指定(原1 档)
        /// 参数1：1-10
        /// 参数2：等待进入下一个动作的时间：单位秒。填0 则无需等待。
        /// </summary>
        AppointStall = 0x0B,
        /// <summary>
        /// 2档
        /// </summary>
        Speed2 = 0x0C,
        /// <summary>
        /// 3档
        /// </summary>
        Speed3 = 0x0D,
        /// <summary>
        /// 4档
        /// </summary>
        Speed4 = 0x0E,
        /// <summary>
        /// 5档
        /// </summary>
        Speed5 = 0x0F,
        /// <summary>
        /// 报警   参数1：0：关蜂鸣报警灯 1：开蜂鸣报警器 参数2：动作等待链接时间  其它：如需常开报警则需写在最后一个动作
        /// </summary>
        Alarm = 0x10,
        /// <summary>
        /// 转到线条
        /// </summary>
        GoToLine = 0x11,
        /// <summary>
        /// 顶升开关
        /// </summary>
        JackUpSwitch = 0x12,
        /// <summary>
        /// 壁障开关
        /// </summary>
        BarrierSwitch = 0x13,
        /// <summary>
        /// 紧急刹车
        /// </summary>
        Estop = 0x14,
        /// <summary>
        /// 输出
        /// </summary>
        Output = 0x15,
        /// <summary>
        /// 数据上传
        /// </summary>
        DataPpload = 0x16,
        /// <summary>
        /// 节点跳转
        /// </summary>
        NodeJump = 0x17,
        /// <summary>
        /// 左转90°
        /// </summary>
        TurnLeft90 = 0x18,
        /// <summary>
        /// 左转180°
        /// </summary>
        TurnLeft180 = 0x19,
        /// <summary>
        /// 切换线路
        /// </summary>
        SwitchingRoute = 0x1A,
        /// <summary>
        /// 升降移载
        /// </summary>
        LiftingSndShifting = 0x1B,
        /// <summary>
        /// 恢复巡线 参数1：ABC：
        ///A = 0 恢复停止前方A = 1 恢复到停止前的返方向；
        ///BC：巡线速度，范围00-10。
        ///参数2: 必须填0
        /// </summary>
        RecoveryPatrolLine = 0x1C,
        /// <summary>
        /// 右转90°
        /// </summary>
        TurnRight90 = 0x1D,
        /// <summary>
        /// 右转180°
        /// </summary>
        TurnRight180 = 0x1E,
        /// <summary>
        /// 左转指定度数
        /// </summary>
        TurnLeftDegrees = 0x1F,
        /// <summary>
        /// 右转指定度数
        /// </summary>
        TurnRIghtDegrees = 0x20,
        /// <summary>
        /// 车体交换
        /// </summary>
        CarBodyReversing = 0x22,
        /// <summary>
        /// 逻辑转向
        /// </summary>
        LogicalCommutation = 0x23,
        /// <summary>
        /// 等待
        /// </summary>
        Wait = 0x24,
        /// <summary>
        /// 清楚节点数据
        /// </summary>
        CleanUp = 0xFF
    }

    public enum eNodeNumber:byte
    {
        Undefined = 0x00,
        Node_1 = 0x01,
        Node_2 = 0x02,
        Node_3 = 0x03,
        Node_4 = 0x04,
        Node_5 = 0x05,
        Node_6 = 0x06,
        Node_7 = 0x07,
        Node_8 = 0x08,
        Node_9 = 0x09,
        Node_10 = 0x0A,
        Node_11= 0x0B,
        Node_12 = 0x0C,
        Node_13 = 0x0D,
        Node_14 = 0x0E,
        Node_15 = 0x0F,
        Node_16 = 0x10,
        Node_17 = 0x11,
        Node_18 = 0x12,
        Node_19 = 0x13,
        Node_20 = 0x14,
        ClearNode = 0xFF
    }
    public class trafficControlCommand : AgvCommandBase
    {
        /// <summary>
        /// 1-50．节点编号为255 即0XFF 时，表示清除交通控制的节点数据
        /// </summary>
        [Proto(2)]
        public eNodeNumber NodeNumber { get; set; } = 0x00;
        [Proto(3)]
        public eAction ActionNumber1 { get; set; } = 0x00;
        [Proto(4)]
        public byte Parameter1_1 { get; set; } = 0x00;
        [Proto(5)]
        public byte Parameter1_2 { get; set; } = 0x00;
        [Proto(6)]
        public eAction ActionNumber2 { get; set; } = 0x00;
        [Proto(7)]
        public byte Parameter2_1 { get; set; } = 0x00;
        [Proto(8)]
        public byte Parameter2_2 { get; set; } = 0x00;
        [Proto(9)]
        public eAction ActionNumber3 { get; set; } = 0x00;
        [Proto(10)]
        public byte Parameter3_1 { get; set; } = 0x00;
        [Proto(11)]
        public byte Parameter3_2 { get; set; } = 0x00;
        [Proto(12)]
        public eAction ActionNumber4 { get; set; } = 0x00;
        [Proto(13)]
        public byte Parameter4_1 { get; set; } = 0x00;
        [Proto(14)]
        public byte Parameter4_2 { get; set; } = 0x00;
        [Proto(15)]
        public byte StartingSirectionSpecifiedSpeed { get; set; } = 0x00;
        [Proto(16)]
        public byte Data15 { get; set; } = 0x00;
        [Proto(17)]
        public byte Data16 { get; set; } = 0x00;

        /// <summary>
        /// 实时交通控制(节点动作设置，断电不保存)
        /// </summary>
        /// <param name="vehicleNumber">AGV编号</param>
        /// <param name="nodeNumber">节点编号</param>
        /// <param name="actionNumber1">动作编号1</param>
        /// <param name="parameter1_1">动作编号1 参数1-1param>
        /// <param name="parameter1_2">动作编号1 参数1-2</param>
        /// <param name="actionNumber2">动作编号2<param>
        /// <param name="parameter2_1">动作编号2 参数2-1</param
        /// <param name="parameter2_2">动作编号2 参数2-2</param>
        /// <param name="actionNumber3">动作编号3</param>
        /// <param name="parameter3_1">动作编号3 参数3-1</param>
        /// <param name="parameter3_2">动作编号3 参数3-2</param>
        /// <param name="actionNumber4">动作编号4</param>
        /// <param name="parameter4_1">动作编号4 参数4-1</param>
        /// <param name="parameter4_2">动作编号4 参数4-2</param>
        /// <param name="startingSirectionSpecifiedSpeed">起动键方向 | 指定速度,</param>
        public trafficControlCommand(byte vehicleNumber, eNodeNumber nodeNumber, eAction actionNumber1 = 0x00, byte parameter1_1 = 0x00, byte parameter1_2 = 0x00, eAction actionNumber2 = 0x00, byte parameter2_1 = 0x00, byte parameter2_2 = 0x00, eAction actionNumber3 = 0x00, byte parameter3_1 = 0x00, byte parameter3_2 = 0x00, eAction actionNumber4 = 0x00, byte parameter4_1 = 0x00, byte parameter4_2 = 0x00, byte startingSirectionSpecifiedSpeed = 0x00000000) :
            base(eAgvCommandWord.trafficControl, vehicleNumber)
        {
            NodeNumber = nodeNumber;
            ActionNumber1 = actionNumber1;
            Parameter1_1 = parameter1_1;
            Parameter1_2 = parameter1_2;
            ActionNumber2 = actionNumber2;
            Parameter2_1 = parameter2_1;
            Parameter2_2 = parameter2_2;
            ActionNumber3 = actionNumber3;
            Parameter3_1 = parameter3_1;
            Parameter3_2 = parameter3_1;
            ActionNumber4 = actionNumber4;
            Parameter4_1 = parameter4_1;
            Parameter4_2 = parameter4_1;
            StartingSirectionSpecifiedSpeed = startingSirectionSpecifiedSpeed;
            DNHead = vehicleNumber;
            Check = (byte)(CommandWord + NodeNumber + (byte)ActionNumber1 + Parameter1_1 + Parameter1_2 + (byte)ActionNumber2 + Parameter2_1 + Parameter2_2 + (byte)ActionNumber3 + Parameter3_1 + Parameter3_2 + (byte)ActionNumber4 + Parameter4_1 + Parameter4_2 + StartingSirectionSpecifiedSpeed + Data15 + Data16);
        }
    }
}
