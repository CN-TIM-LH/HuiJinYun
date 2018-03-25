using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity
{
    [Serializable]
    public class PLCCMD
    {
        /// <summary>
        /// 副帧头
        /// </summary>
        public byte[] Subframe { get; set; } = { 0x50, 0x00 };
        /// <summary>
        /// 网络编号
        /// </summary>
        public byte[] NetNo { get; set; } = { 0x00 };
        /// <summary>
        /// PC编号
        /// </summary>
        public byte[] PCNo { get; set; } = { 0xFF};
        /// <summary>
        /// I/O编号请求目标模块
        /// </summary>
        public byte[] IONo { get; set; } = { 0x03, 0xFF };
        /// <summary>
        /// 请求目标多点站号
        /// </summary>
        public byte[] StationNo { get; set; } = { 0x00 };
        /// <summary>
        /// 请求数据长
        /// </summary>
        public byte[] DataLength { get; set; } = { 0x0C, 0x00 };
        /// <summary>
        /// 保留数据
        /// </summary>
        public byte[] Retain { get; set; } = { 0x00, 0x10 };
        /// <summary>
        /// 指令
        /// </summary>
        public byte[] Instructions { get; set; }
        /// <summary>
        /// 子指令
        /// </summary>
        public byte[] SubInstructions { get; set; }

        /// <summary>
        /// 请求数据
        /// </summary>
        public byte[] PostData { get; set; } = { };
    }
}
