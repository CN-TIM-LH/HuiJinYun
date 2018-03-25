using HuiJinYun.Domain.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.PLC
{
    public class ReadRandomResult : PlcResultBase
    {
        [Proto(11, 2)]
        public UInt16 WordData { get; set; }

        public ReadRandomResult() :
            base(ePlcResultCode.OK, 0)
        {
        }
    }
}
