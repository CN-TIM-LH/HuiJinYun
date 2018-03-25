using HuiJinYun.Domain.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.AGV
{
    public enum eCardXIPResultType:byte
    {
        /// <summary>
        /// 成功
        /// </summary>
        Success = 0x01,
        /// <summary>
        /// 失败
        /// </summary>
        fail = 0x00
    }
    class CardXIPResult : AgvResultBase
    {
        /// <summary>
        /// 结果
        /// </summary>
        [Proto(2)]
        public eCardXIPResultType Result { get; set; }
        public CardXIPResult() : 
            base(eAgvResultWord.CardXIP)
        {
        }
    }
}
