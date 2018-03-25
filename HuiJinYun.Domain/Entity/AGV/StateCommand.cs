using HuiJinYun.Domain.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.AGV
{
    /// <summary>
    /// 状态信息
    /// </summary>
    public class StateCommand : AgvCommandBase
    {
        [Proto(2)]
        public byte Data1 { get; set; } = 0x00;
        [Proto(3)]
        public byte Data2 { get; set; } = 0x00;
        [Proto(4)]
        public byte Data3 { get; set; } = 0x00;
        [Proto(5)]
        public byte Data4 { get; set; } = 0x00;
        [Proto(6)]
        public byte Data5 { get; set; } = 0x00;
        [Proto(7)]
        public byte Data6 { get; set; } = 0x00;
        [Proto(8)]
        public byte Data7 { get; set; } = 0x00;
        [Proto(9)]
        public byte Data8 { get; set; } = 0x00;
        [Proto(10)]
        public byte Data9 { get; set; } = 0x00;
        [Proto(11)]
        public byte Data10 { get; set; } = 0x00;
        [Proto(12)]
        public byte Data11 { get; set; } = 0x00;
        [Proto(13)]
        public byte Data12 { get; set; } = 0x00;
        [Proto(14)]
        public byte Data13 { get; set; } = 0x00;
        [Proto(15)]
        public byte Data14 { get; set; } = 0x00;
        [Proto(16)]
        public byte Data15 { get; set; } = 0x00;
        [Proto(17)]
        public byte Data16 { get; set; } = 0x00;
        public StateCommand(byte vehicleNumber) :
            base(eAgvCommandWord.State, vehicleNumber)
        {
            DNHead = vehicleNumber;
            Check = (byte)(CommandWord + Data1 + Data2 + Data3 + Data4 + Data5 + Data6 + Data7 + Data8 + Data9 + Data10 + Data11 + Data12 + Data13 + Data14 + Data15 + Data16);
        }
    }
}
