using HuiJinYun.Domain.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.AGV
{
    /// <summary>
    /// AGV 命令
    /// </summary>
    public enum eAgvCommandWord : byte
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
        /// 实时交通控制 (节点动作设置，断电不保存)
        /// </summary>
        trafficControl = 0x16,
        /// <summary>
        /// 节点编号 (获取/反馈)
        /// </summary>
        NodeNumber = 0x17,
        /// <summary>
        /// 设置输出/开关状态(断电不保存)
        /// </summary>
        Output = 0x18,
        /// <summary>
        /// 路线切换
        /// </summary>
        RouteSwitch = 0x20,
        /// <summary>
        /// 卡片直接执行
        /// </summary>
        CardXIP = 0x2A,
        /// <summary>
        /// 错误报告
        /// </summary>
        ErrorRepored = 0xFF,

    }
    public abstract class AgvCommandBase : IAgvCommand, IProto
    {
        /// <summary>
        /// 下行帧头
        /// </summary>
        [Proto(0)]
        public byte DNHead { get; set; }

        /// <summary>
        /// 命令字
        /// </summary>
        [Proto(1)]
        public byte CommandWord { get; set; }

        /// <summary>
        /// 校验
        /// </summary>
        [Proto(18)]
        public byte Check { get; set; }

        /// <summary>
        /// 下行帧尾
        /// </summary>
        [Proto(19)]
        public byte TailFrame { get; set; }

        public AgvCommandBase(eAgvCommandWord commandWord, byte vehicleNumber)
        {
            CommandWord = (byte)commandWord;
            DNHead = vehicleNumber;
            TailFrame = (byte)(0xFF - vehicleNumber);
        }
    }
}