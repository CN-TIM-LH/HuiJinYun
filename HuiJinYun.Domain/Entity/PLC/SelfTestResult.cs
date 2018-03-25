using HuiJinYun.Domain.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.PLC
{
    public class SelfTestResult : PlcResultBase
    {
        [Proto(11, 2)]
        public UInt16 TestLength { get; set; }
        [Proto(13)]
        public string TestData { get; set; }
        
        public SelfTestResult() :
            base(ePlcResultCode.OK, 0)
        {

        }
    }
}
