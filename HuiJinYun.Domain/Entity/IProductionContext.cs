using HuiJinYun.Domain.Infrastructure.Watcher;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity
{
    public interface IProductionContext : INotifier
    {
        List<Encapsulation> EncapsulationDevice { get; set; }
        int SN { get; }
        Task<bool> Work();
        Task<bool> Bypass();
        Task<bool> NextStage();
    }
}
