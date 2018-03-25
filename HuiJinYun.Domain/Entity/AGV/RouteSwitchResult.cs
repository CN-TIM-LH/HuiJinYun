using HuiJinYun.Domain.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.AGV
{
    public enum eRouteSwitchState:byte
    {
        Success = 0x00,                   //成功
        Fail = 0x01                       //失败
    }
    class RouteSwitchResult : AgvResultBase
    {
        [Proto(2)]
        public eRouteSwitchState State { get; set;}
        public RouteSwitchResult() :
            base(eAgvResultWord.RouteSwitch)
        {
        }
    }
}
