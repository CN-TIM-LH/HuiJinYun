using HuiJinYun.Domain.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity
{
    public enum eAGVState
    {
        None = 0x000000,
        FontLIR = 0x000001,
        FontSIR = 0x000002,
        FontSafeLine = 0x000004,
        BackLIR = 0x000008,
        BackSIR = 0x000010,
        BackSafeLine = 0x000020,
        FontIR = 0x000040,
        BackIR = 0x000080,
        FontEStop = 0x000100,
        BackEStop = 0x000200,
        BackupOff = 0x000400,
        BackupFPatrol = 0x000800,
        BackupBPatrol = 0x001000,
        LeftAlert = 0x010000,
        RightAlert = 0x020000,
        Dispatch = 0x040000,
        Power = 0x080000
    }

    public enum eAGVDirection
    {
        Stop = 0,
        Forward = 1,
        Backward = 2,
        TurnLeft = 3,
        TurnRight = 4,
        FrontPatrol = 5,
        BackPatrol = 6
    }

    public enum eAGVCommand
    {
        /// <summary>
        /// 状态信息
        /// </summary>
        State = 0x01,
        /// <summary>
        /// 运动控制
        /// </summary>
        MotionControl = 0x03,
        /// <summary>
        /// 实时交通控制(节点动作设置，断电不保存)
        /// </summary>
        TrafficControl = 0x16,
        /// <summary>
        /// 节点编号获取/反馈
        /// </summary>
        NodeNumber = 0x17,
        /// <summary>
        /// 设置输出/开关状态(断电不保存)
        /// </summary>
        OutPut = 0x18,
        /// <summary>
        /// 路线切换
        /// </summary>
        RouteSwitch = 0x20,
        /// <summary>
        /// 卡片直接执行
        /// </summary>
        CardExecution = 0x2A,
        /// <summary>
        /// 错误报告
        /// </summary>
        ErrorReporting = 0xFF
    }


    public class agvState : IProto
    {
      
        //public int DNHEAD { get; set; }

        

        [Proto(2, 3)]
        public eAGVState State { get; set; }

        /// <summary>
        /// 数据3 (运动方向)
        /// 0-停止，1-前进，2-后退，3-左转，4-右转，5-前巡，6-后巡(含其他动作单元)
        /// </summary>
        [Proto(5)]
        public eAGVDirection Direction { get; set; }


        /// <summary>
        /// 数据4 (运动速度档位)
        /// AGV 实时运动速度档位，0-10(不同设备可能档位不一样)
        /// </summary>
        [Proto(6)]
        public int MovementSpeedGear { get; set; }

        /// <summary>
        /// 数据5 (保留0)
        /// </summary>
        public int MovementStroke { get; set; }

        /// <summary>
        ///数据6 (前巡线-低8 位  巡线传感器状态)
        /// </summary>
        public int Front_PatrolLine_low { get; set; }

        /// <summary>
        ///数据7 (后巡线-低8 位  巡线传感器状态)
        /// </summary>
        public int After_PatrolLine_low { get; set; }

        /// <summary>
        ///数据8 (前巡线-高8 位  当前路线编号-V2.043)
        /// </summary>
        public int Front_PatrolLine_High { get; set; }

        /// <summary>
        ///数据9 (后巡线-高8 位  巡线传感器状态，没有则保留)
        /// </summary>
        public int After_PatrolLine_High { get; set; }

        /// <summary>
        /// 数据10 (内部保留其他用途外部不可使用)
        /// </summary>
        public int  InternalReservation_1 { get; set; }

        /// <summary>
        /// 数据11 (内部保留其他用途外部不可使用)
        /// </summary>
        public int InternalReservation_2 { get; set; }

        /// <summary>
        /// 数据12 (内部保留其他用途外部不可使用)
        /// </summary>
        public int InternalReservation_3 { get; set; }

        /// <summary>
        /// 数据13 (内部保留其他用途外部不可使用)
        /// </summary>
        public int InternalReservation_4 { get; set; }

        /// <summary>
        /// 数据14 (最新错误代码)
        /// </summary>
        public int RrrorCode { get; set; }


        /// <summary>
        /// 数据15 (最新节点编号 最新节点编号，功能卡则显示0XFF)
        /// </summary>
        public int NodeNumber { get; set; }

      
    }

    public class AGVCarUpData
    {
        /// <summary>
        /// 帧头 DNHEAD(即小车编号): 0X01~0XFF
        /// </summary>
        public object UPHEAD { get; set; }

        /// <summary>
        /// 命令字节
        /// </summary>
        public object Command { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public byte[] Data { get; set; }

        /// <summary>
        /// 校验和
        /// </summary>
        public object Checksum { get; set; }

        /// <summary>
        /// 帧尾
        /// </summary>
        public object UPEND { get; set; }

    }
}
