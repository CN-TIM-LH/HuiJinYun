using HuiJinYun.Domain.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.AGV
{

    public enum eSwitchNumber : byte
    {
        /// <summary>
        /// 声光报警器
        /// </summary>
        AcoustoopticAlarm = 0x01,
        /// <summary>
        /// 状态主动上传    (默认主动)
        /// </summary>
        StatusActiveUpload = 0x02,
        /// <summary>
        /// 节点编号主动上传(默认主动)
        /// </summary>
        NodeNumberActiveUpload = 0x03,
        /// <summary>
        /// 避障开关
        /// </summary>
        BarrierSwitch = 0x04,
        /// <summary>
        /// 小范围避障开关
        /// </summary>
        SmallRangeObstacleAvoidanceSwitch = 0x05,
        /// <summary>
        /// 调度心跳开关
        /// </summary>
        DispatchingHeartbeatSwitch = 0x06,
        /// <summary>
        /// 备用输出 1
        /// </summary>
        SpareOutput_1 = 0x0A,
        /// <summary>
        /// 备用输出 2
        /// </summary>
        SpareOutput_2 = 0x0B,
        /// <summary>
        /// 备用输出 3
        /// </summary>
        SpareOutput_3 = 0x0C,
        /// <summary>
        /// 备用输出 4
        /// </summary>
        SpareOutput_4 = 0x0D,
        /// <summary>
        /// 批量设置备用输出：从数据2 开始的4 个字节分别表示备用1-4 的开关状态，0-关，1-开，2-不变。
        /// </summary>
        SpareOutput_ALL = 0X2F                      
    }
    public enum eSwitchStates : byte
    {
        /// <summary>
        /// 开
        /// </summary>
        Open = 0x01,
        //关
        Shut = 0x00
    }

    public class OutputCommand : AgvCommandBase
    {
        [Proto(2)]
        public eSwitchNumber SwitchNumber { get; set; }   //开关编号
        [Proto(3)]
        public eSwitchStates SwitchState { get; set; }   //开关状态
        [Proto(4)]
        public byte Data3 { get; set; } = 0x00;
        [Proto(5)]
        public byte Data4 { get; set; } = 0x00;
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

        /// <summary>
        /// 设置输出/开关状态(断电不保存)
        /// </summary>
        /// <param name="vehicleNumber">车辆编号</param>
        /// <param name="switchNumber">开关编号</param>
        /// <param name="switchState">开关状态</param>
        public OutputCommand(byte vehicleNumber, eSwitchNumber switchNumber, eSwitchStates switchState) :
            base(eAgvCommandWord.Output, vehicleNumber)
        {
            SwitchNumber = switchNumber;
            SwitchState = switchState;
            DNHead = vehicleNumber;
            Check += (byte)(CommandWord + (UInt16)SwitchNumber + (UInt16)SwitchState + Data3 + Data4 + Data5 + Data6 + Data7 + Data8 + Data9 + Data10 + Data11 + Data12 + Data13 + Data14 + Data15 + Data16);
        }
    }
}