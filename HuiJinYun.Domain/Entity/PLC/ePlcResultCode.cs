using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.PLC
{
    public enum ePlcResultCode : UInt16
    {
        OK = 0x0000,
        CannotWriteWhenRun = 0x0055,
        ReadWriteBitExceeded = 0xC051,
        ReadWriteWordExceeded = 0xC052,
        RandomReadWriteBitExceeded = 0xC053,
        RandomReadWriteWordExceeded = 0xC054,
        ReadWriteAddressExceeded = 0x0056,
        InvalidInstruction = 0xC059,
        CannotReadWrite = 0xC05B,
        ReadWriteBitDataError = 0xC05C,
        CannotImplement = 0xC05F,
        WriteBitError = 0xC060,
        DataLenghtError = 0xC061,
        PasswordError = 0xC200,
    }
}
