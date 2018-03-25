using HuiJinYun.Domain.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.PLC
{
    public enum ePlcModel : UInt16
    {
        Null = 0,
        FX5U32MRES = 0x4A21,
        FX5U64MRES = 0x4A23,
        FX5U80MRES = 0x4A24,
        FX5U32MTES = 0x4A29,
        FX5U64MTES = 0x4A2b,
        FX5U80MTES = 0x4A2c,
        FX5U32MTESS = 0x4A31,
        FX5U64MTESS = 0x4A33,
        FX5U80MTESS = 0x4A34,
        FX5UC32MTD = 0x4A91,
        FX5UC32MTDSS = 0x4A99,
    }
    public class ReadTypeNameResult : PlcResultBase
    {
        [Proto(11, 16)]
        public string ModelName { get; set; }

        /// <summary>
        /// CPU模块型号
        /// </summary>
        [Proto(27, 2)]
        public ePlcModel Model { get; set; }
        public ReadTypeNameResult() :
            base(ePlcResultCode.OK, 0)
        {
        }
    }
}
