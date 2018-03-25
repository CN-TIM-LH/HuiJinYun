using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.PLC
{
    public enum ePlcInstructions : UInt32
    {
        Read_WORD = 0x04010000,
        Read_BIT = 0x04010001,
        Write_WORD = 0x14010000,
        ReadRandom_WORD = 0x04030000,
        WriteRandom_WORD = 0x14020000,
        WriteRandom_BIT = 0x14020001,
        ReadBlock = 0x04060000,
        WriteBlock = 0x14060000,
        #region Remote Instructions
        RemoteRun = 0x10010000,
        RemoteStop = 0x10020000,
        RemotePause = 0x10030000,
        RemoteClear = 0x10050000,
        RemoteReset = 0x10060000,
        #endregion
        #region Other
        ReadTypeName = 0x01010000,
        Global_Off = 0x16180000,
        Global_On = 0x16180001,
        SelfTest = 0x06190000,
        ClearError = 0x16170000,
        PasswordLock = 0x16310000,
        PasswordUnlock = 0x16300000,
        #endregion
    }
}
