using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.PLC
{
    public class ClearErrorCommand : PlcCommandBase
    {
        public ClearErrorCommand() : base(ePlcInstructions.ClearError, 0) { }
    }
}
