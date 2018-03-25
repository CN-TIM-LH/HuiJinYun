using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.PLC
{
    public class ReadTypeNameCommand : PlcCommandBase
    {
        public ReadTypeNameCommand() : base(ePlcInstructions.ReadTypeName, 0) { }
    }
}
