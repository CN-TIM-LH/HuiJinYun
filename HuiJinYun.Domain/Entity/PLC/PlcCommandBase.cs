using HuiJinYun.Domain.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.PLC
{
    public class PlcCommandBase : IPlcCommand, IProto
    {
        /// <summary>
        /// 副帧头
        /// </summary>
        [Proto(0, 2)]
        public UInt16 SubFrame { get; set; } = 0x0050;
        /// <summary>
        /// 网络编号
        /// </summary>
        [Proto(2)]
        public byte NetNo { get; set; } = 0x00;
        /// <summary>
        /// PC编号
        /// </summary>
        [Proto(3)]
        public byte PCNo { get; set; } = 0xFF;
        /// <summary>
        /// I/O编号请求目标模块
        /// </summary>
        [Proto(4, 2)]
        public UInt16 IONo { get; set; } = 0x03FF;
        /// <summary>
        /// 请求目标多点站号
        /// </summary>
        [Proto(6)]
        public byte StationNo { get; set; } = 0x00;
        /// <summary>
        /// 请求数据长
        /// </summary>
        [Proto(7, 2)]
        public UInt16 DataLength { get; set; }
        /// <summary>
        /// 保留数据
        /// </summary>
        [Proto(9, 2)]
        public UInt16 Retain { get; set; } = 0x0010;
        /// <summary>
        /// 指令
        /// </summary>
        [Proto(11, 2)]
        public UInt16 Instructions { get; set; }
        /// <summary>
        /// 子指令
        /// </summary>
        [Proto(13, 2)]
        public UInt16 SubInstructions { get; set; }

        public PlcCommandBase() : this(ePlcInstructions.ClearError, 0) { }
        public PlcCommandBase(ePlcInstructions instruction, UInt16 lenght)
        {
            DataLength = (UInt16)(lenght + 6);
            Instructions = (UInt16)((UInt32)instruction >> 16);
            SubInstructions = (UInt16)((UInt32)instruction & 0x0000FFFF);
        }
    }
}
