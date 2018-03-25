using HuiJinYun.Domain.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.AGV
{
    class ErrorReportingResult : AgvResultBase
    {
        [Proto(2)]
        public byte ErrorCode {get;set;}
        [Proto(2)]
        public byte ErrorCommandWord { get; set; }
        public ErrorReportingResult() : 
            base(eAgvResultWord.ErrorRepored)
        {

        }
    }
}
