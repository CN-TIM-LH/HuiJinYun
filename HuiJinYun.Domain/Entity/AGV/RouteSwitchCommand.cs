using HuiJinYun.Domain.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.AGV
{
 public   class RouteSwitchCommand : AgvCommandBase
    {
        [Proto(2)]
        public byte SwitchTargetPathNumber { get; set; }                   //切换目标路线号
        [Proto(3)]
        public byte TargetRouteNumber { get; set; }                        //在卡片切换时的目标路线号
        [Proto(4)]
        public byte parameter_1 { get; set; } = 0x00;
        [Proto(5)]
        public byte parameter_2 { get; set; } = 0x00;
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

        /// <summary>
        /// 路线切换
        /// </summary>
        /// <param name="vehicleNumber">车辆编号</param>
        /// <param name="switchTargetPathNumber">切换目标路线号</param>
        /// <param name="targetRouteNumber">在卡片切换时的目标路线号</param>
        public RouteSwitchCommand(byte vehicleNumber, byte switchTargetPathNumber, byte targetRouteNumber) :
            base(eAgvCommandWord.RouteSwitch, vehicleNumber)
        {
            SwitchTargetPathNumber = switchTargetPathNumber;
            TargetRouteNumber = targetRouteNumber;
            DNHead = vehicleNumber;
            Check = (byte)(CommandWord + SwitchTargetPathNumber + TargetRouteNumber + parameter_1 + parameter_2 + Data5 + Data6 + Data7 + Data8 + Data9 + Data10 + Data11 + Data12 + Data13 + Data14 + Data15 + Data16);
        }
    }
}
