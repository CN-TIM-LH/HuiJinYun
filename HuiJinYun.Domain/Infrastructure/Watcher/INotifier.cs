using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Infrastructure.Watcher
{
    public delegate void NotifyEventHandler(object sender, NotifyArgs args);

    public interface INotifier
    {
        event NotifyEventHandler OnNotify;
    }
}
