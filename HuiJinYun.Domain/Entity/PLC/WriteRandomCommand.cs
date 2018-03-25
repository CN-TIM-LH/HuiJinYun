using HuiJinYun.Domain.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.PLC
{
    public class WriteRandomCommand : PlcCommandBase
    {
        [Proto(15)]
        public byte WordLength { get; set; }

        [Proto(16)]
        public byte DWordLength { get; set; }

        [Proto(17, 4)]
        public UInt32 WordNumber { get; set; }

        [Proto(21, 2)]
        public UInt16 WordData { get; set; }

        public UInt32 DWordNumber { get; set; }

        public UInt16 DWordData { get; set; }

        public WriteRandomCommand(eElementCode code, UInt32 number, UInt16 data) :
            base(ePlcInstructions.WriteRandom_WORD, 8)
        {
            WordLength = 1;
            DWordLength = 0;
            WordNumber = (UInt32)code | (number & 0x00FFFFFF);
            WordData = data;
        }
    }
}
