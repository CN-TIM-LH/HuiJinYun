using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.AGV
{
    class MotionControlResult : AgvResultBase
    {

        public MotionControlResult() :
            base(eAgvResultWord.MotionControl)
        {
        }
    }
}
