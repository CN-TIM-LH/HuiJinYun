using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity
{
    public enum eProductionStageState
    {
        Stop,      //停止
        Pause,     //暂停
        Idle,      //空闲
        Busy,      //工作中
        Ready,     //准备就绪
        Finish,    //完成
        Error      //错误
    }

    public interface IProductionStage
    {
        eProductionStageState Status { get; }
        IProductionStage Work(object args, out object result);
        Task<IProductionStage> Work(object args);
        IProductionStage Bypass(object args, out object result);
    }
}
