using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity
{
    public interface IProductionLine
    {
        IProductionLine Program(Func<IProductionContext, Task<bool>> func);
        IProductionLine Start(int mode);
        IProductionLine Pause(int mode);
        IProductionLine Stop(int mode);
    }
}
