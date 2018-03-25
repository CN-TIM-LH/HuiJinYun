using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.PLC
{
    public class WriteRandomBitCommand : PlcCommandBase
    {
        public WriteRandomBitCommand() : base(ePlcInstructions.WriteRandom_BIT, 1)
        {

        }
    }
}
