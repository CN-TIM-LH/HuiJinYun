using HuiJinYun.Domain.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.PLC
{
    public class WriteCommand : PlcCommandBase
    {
        [Proto(15, 4)]
        public UInt32 WordNumber { get; set; }

        [Proto(19, 2)]
        public UInt16 Count { get; set; }

        public UInt16[] Data { get; set; }

        public WriteCommand(eElementCode wordCode, UInt32 wordNumber, UInt16 count, UInt16[] data = null) :
            base(ePlcInstructions.Write_WORD, (ushort)(6 + (count * 2)))
        {
            WordNumber = (UInt32)wordCode | (wordNumber & 0x00FFFFFF);
            Count = count;
            if (null != data)
                Array.Copy(data, Data, count);
        }
    }
}
