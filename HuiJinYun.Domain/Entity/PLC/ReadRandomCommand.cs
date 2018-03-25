using HuiJinYun.Domain.Infrastructure.Common;
using System;

namespace HuiJinYun.Domain.Entity.PLC
{
    public class ReadRandomCommand : PlcCommandBase
    {
        [Proto(15)]
        public byte WordLength { get; set; }

        [Proto(16)]
        public byte DWordLength { get; set; }

        [Proto(17, 4)]
        public UInt32 WordNumber { get; set; }

        //[Proto(21, 4)]
        public UInt32 DWordNumber { get; set; }

        public ReadRandomCommand(eElementCode wordCode, UInt32 wordNumber, eElementCode dwordCode = eElementCode.Null, UInt32 dwordNumber = 0) : base(ePlcInstructions.ReadRandom_WORD, 6)
        {
            WordLength = 1;
            DWordLength = 0;
            WordNumber = (UInt32)wordCode | (wordNumber & 0x00FFFFFF);
            DWordNumber = (UInt32)dwordCode | (dwordNumber & 0x00FFFFFF);
        }
    }
}
