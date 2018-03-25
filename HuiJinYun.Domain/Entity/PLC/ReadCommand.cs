using HuiJinYun.Domain.Infrastructure.Common;
using System;

namespace HuiJinYun.Domain.Entity.PLC
{
    public class ReadCommand : PlcCommandBase
    {
        [Proto(15, 4)]
        public UInt32 WordNumber { get; set; }

        [Proto(19, 2)]
        public UInt16 Count { get; set; }

        public ReadCommand(eElementCode wordCode, UInt32 wordNumber, UInt16 count) : base(ePlcInstructions.Read_WORD, 6)
        {
            WordNumber = (UInt32)wordCode | (wordNumber & 0x00FFFFFF);
            Count = count;
        }
    }
}
