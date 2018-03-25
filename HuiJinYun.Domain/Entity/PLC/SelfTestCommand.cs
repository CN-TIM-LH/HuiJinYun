using HuiJinYun.Domain.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.PLC
{
    public class SelfTestCommand : PlcCommandBase
    {
        [Proto(15, 2)]
        public UInt16 TestLength { get; set; }
        [Proto(17)]
        public string TestData { get; set; }
        public SelfTestCommand(string testData = "0123456789ABCDEFGHJLKMNOPQRSTUVWXYZ") :
            base(ePlcInstructions.SelfTest, (UInt16)(testData.Length + 2))    // base(ePlcInstructions.SelfTest, (UInt16)(testData.Length + 1))
        {
            TestLength = (UInt16)(testData.Length);
            TestData = testData;                                                                                                                                                                                                                        
        }
    }
}
