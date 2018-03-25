using HuiJinYun.Domain.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.AGV
{
    //方向命令
    public enum eMoveDirection : byte
    {
        Stop = 0x01,            //停止
        Advancing = 0x01,       //前进
        BackOff = 0x02,         //后退
        TurnLeft = 0x03,        //左转
        TurnRight = 0x04,       //右转
        FrontPatrol = 0x05,     //前巡
        RearPatrol = 0x06,      //后巡
        EStop = 0XFF,           //急停
        TrayUp = 0x07,          //顶升上(滚筒前进)
        TrayDoen = 0x08,        //顶升下(滚筒后退),
        Dstop = 0x09,           //对接停，A-辊筒左，B-辊筒右，C-辊筒停。（定制机型）
    }

    //速度
    public enum eSpeed : byte
    {
        Speed0 = 0x00,   //速度 0
        Speed1 = 0x01,   //速度 1
        Speed2 = 0x02,   //速度 2
        Speed3 = 0x03,   //速度 3
        Speed4 = 0x04,   //速度 4
        Speed5 = 0x05,   //速度 5
        Speed6 = 0x06,   //速度 6
        Speed7 = 0x07,   //速度 7
        Speed8 = 0x08,   //速度 8
        Speed9 = 0x09,   //速度 9
        Speed10 = 0x0A,  //速度 10
    }

    //逻辑方向
    public enum eLogicalDirection : byte
    {
        LogicalGo = 0XEE,   //逻辑往
        LogicalReturn = 0XFF   //罗辑返
    }
    /// <summary>
    /// 运动控制
    /// </summary>
    public class MotionControlCommand : AgvCommandBase
    {
        [Proto(2)]
        public eMoveDirection MoveDirection { get; set; }
        [Proto(3)]
        public eSpeed Speed { get; set; }
        [Proto(4)]
        public eLogicalDirection LogicalDirection { get; set; } = 0x00;
        [Proto(5)]
        public byte MovementTime { get; set; } = 0x00;
        [Proto(6)]
        public byte Data5 { get; set; } = 0x00;
        [Proto(7)]
        public byte Data6 { get; set; } = 0x00;
        [Proto(8)]
        public byte Data7 { get; set; } = 0x00;
        [Proto(9)]
        public byte Data8 { get; set; } = 0x00;
        [Proto(10)]
        public byte Data9 { get; set; } = 0x00;
        [Proto(11)]
        public byte Data10 { get; set; } = 0x00;
        [Proto(12)]
        public byte Data11 { get; set; } = 0x00;
        [Proto(13)]
        public byte Data12 { get; set; } = 0x00;
        [Proto(14)]
        public byte Data13 { get; set; } = 0x00;
        [Proto(15)]
        public byte Data14 { get; set; } = 0x00;
        [Proto(16)]
        public byte Data15 { get; set; } = 0x00;
        [Proto(17)]
        public byte Data16 { get; set; } = 0x00;

        public MotionControlCommand(byte vehicleNumber, eMoveDirection moveDirection, eSpeed speed, eLogicalDirection logicalDirection = eLogicalDirection.LogicalGo, byte movementTime =0x00) :
            base(eAgvCommandWord.MotionControl, vehicleNumber)
        {
            DNHead = vehicleNumber;
            MoveDirection = moveDirection;
            Speed = speed;
            LogicalDirection = logicalDirection;
            MovementTime = movementTime;
            Check = (byte)(CommandWord + MoveDirection + (byte)Speed + (byte)LogicalDirection + MovementTime + Data5 + Data6 + Data7 + Data8 + Data9 + Data10 + Data11 + Data12 + Data13 + Data14 + Data15 + Data16);
        }
    }
}
