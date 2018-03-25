using HuiJinYun.Domain.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.PLC
{
    public class RemoteResetCommand : PlcCommandBase
    {
        [Proto(15, 2)]
        public UInt16 Data { get; set; } = 0x0000;
        public RemoteResetCommand() : base(ePlcInstructions.RemoteReset, 2) { }
    }
}
