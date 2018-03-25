using HuiJinYun.Domain.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.PLC
{
    public class PlcResultBase : IPlcResult, IProto
    {
        /// <summary>
        /// 副帧头
        /// </summary>
        [Proto(0, 2)]
        public UInt16 SubFrame { get; set; } = 0x00D0;//UInt16
        /// <summary>
        /// 网络编号
        /// </summary>
        [Proto(2)]
        public Byte NetNo { get; set; } = 0x00; //Byte
        /// <summary>
        /// PC编号 (访问站)
        /// </summary>
        [Proto(3)]
        public Byte PCNo { get; set; } = 0xFF;//Byte
        /// <summary>
        /// I/O编号请求目标模块 (访问站)
        /// </summary>
        [Proto(4, 2)]
        public UInt16 IONo { get; set; } = 0x03FF; //UInt16
        /// <summary>
        /// 请求目标多点站号
        /// </summary>
        [Proto(6)]
        public byte StationNo { get; set; } = 0x00; //byte
        /// <summary>
        /// 响应数据长
        /// </summary>
        [Proto(7, 2)]
        public UInt16 DataLength { get; set; } //UInt16
        /// <summary>
        /// 结束代码
        /// </summary>
        [Proto(9, 2)]
        public ePlcResultCode Code { get; set; }

        public PlcResultBase() : this(ePlcResultCode.OK, 0) { }

        public PlcResultBase(ePlcResultCode code, UInt16 lenght)
        {
            DataLength = (UInt16)(lenght + 2);
            Code = code;
        }
    }
}
