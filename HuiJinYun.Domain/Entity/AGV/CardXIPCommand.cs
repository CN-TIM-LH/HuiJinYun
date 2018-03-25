using HuiJinYun.Domain.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.AGV
{
    class CardXIPCommand : AgvCommandBase
    {
        [Proto(2)]
        public byte CardNumber { get; set; } = 0x00;                      //卡号
        [Proto(3)]
        public byte LogicalDirection { get; set; } = 0x00;                //逻辑方向
        [Proto(4)]
        public byte RouteNumber { get; set; } = 0x00;                     //路线编号
        [Proto(5)]
        public byte Parameter { get; set; } = 0x00;                     //参数2
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
        /// 卡片直接执行
        /// </summary>
        /// <param name="vehicleNumber">AGV编号</param>
        /// <param name="cardNumber">卡片编号</param>
        /// <param name="logicalDirection">逻辑方向</param>
        /// <param name="routeNumber">路线编号</param>
        /// <param name="parameter">参数</param>
        public CardXIPCommand(byte vehicleNumber, byte cardNumber, byte logicalDirection = 0x00, byte routeNumber = 0x00, byte parameter = 0x00) :
            base(eAgvCommandWord.CardXIP, vehicleNumber)
        {
            DNHead = vehicleNumber;
            CardNumber = cardNumber;
            LogicalDirection = logicalDirection;
            RouteNumber = routeNumber;
            Parameter= parameter;
            Check = (byte)(CommandWord + CardNumber + LogicalDirection + RouteNumber + Parameter + Data5 + Data6 + Data7 + Data8 + Data9 + Data10 + Data11 + Data12 + Data13 + Data14 + Data15 + Data16);
        }
    }
}
