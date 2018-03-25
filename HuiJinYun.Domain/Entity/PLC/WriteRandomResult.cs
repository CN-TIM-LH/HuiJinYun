using HuiJinYun.Domain.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.PLC
{
    public class WriteRandomResult : PlcResultBase
    {
        public WriteRandomResult() :
            base(ePlcResultCode.OK, 0)
        {
        }
    }
}
