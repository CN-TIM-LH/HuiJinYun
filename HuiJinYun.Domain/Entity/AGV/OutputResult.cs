using HuiJinYun.Domain.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.AGV
{
    public enum eOutputResultState : byte
    {
        Success = 0x00,                   //成功
        Fail = 0x01                       //失败
    }
    public class OutputResult : AgvResultBase
    {
        [Proto(2)]
        public eOutputResultState State { get; set; }
        public OutputResult() : 
            base(eAgvResultWord.Output)
        {
        }
    }
}
