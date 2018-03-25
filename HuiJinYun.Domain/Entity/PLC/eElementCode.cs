using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.PLC
{
    public enum eElementCode : UInt32
    {
        Null,
        X = 0x9C000000,
        Y = 0x9D000000,
        M = 0x90000000,
        L = 0x92000000,
        F = 0x93000000,
        V = 0x94000000,
        B = 0xA0000000,
        S = 0x98000000,
        D = 0xA8000000,
        W = 0xB4000000,
        TS = 0xC1000000,
        TC = 0xC0000000,
        TN = 0xC2000000,
        LTS = 0x59000000,
        LTC = 0x58000000,
        LTN = 0x5A000000,
        CS = 0xC4000000,
        CC = 0xC3000000,
        CN = 0xC5000000,
        LCS = 0x55000000,
        LCC = 0x54000000,
        LCN = 0x56000000,
        SB = 0xA1000000,
        SW = 0xB5000000,
        SM = 0x91000000,
        SD = 0xA9000000,
        Z = 0xCC000000,
        LZ = 0x62000000,
        R = 0xAF000000,
        ZR = 0xB0000000,
    }
}
