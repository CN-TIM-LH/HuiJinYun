using HuiJinYun.Domain.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.AGV
{
    public enum etrafficControlState:UInt32
    {
        Success = 0,                   //成功
        Fail = 1                       //失败
    }
    public class trafficControlResult : AgvResultBase
    {
        [Proto(2)]
        public etrafficControlState State { get; set; }
        public trafficControlResult() :
            base(eAgvResultWord.trafficControl)
        {

        }
    }
}
