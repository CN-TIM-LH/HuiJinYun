using HuiJinYun.Domain.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.AGV
{
    class NodeNumberResult : AgvResultBase
    {
        [Proto(2)]
        public byte HightNumberData { get; set; }
        [Proto(3)]
        public byte DownNumberData { get; set; }
        public NodeNumberResult() :
            base(eAgvResultWord.NodeNumber)
        {
        }
    }
}
