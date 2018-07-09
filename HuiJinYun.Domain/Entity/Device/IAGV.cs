using HuiJinYun.Domain.Infrastructure.Watcher;

namespace HuiJinYun.Domain.Entity.Device
{

    public interface IAGV<TState, TPosition> : INotifier
    {
        TState State { get; set; }
        TPosition Position { get; }
        int Number { get;  set; }
        IAGV<TState, TPosition> Goto(TPosition position, int mode = 0);
        IAGV<TState, TPosition> Export(TPosition position, int port, bool enable);
        IAGV<TState, TPosition> checkTrayState();
        IAGV<TState, TPosition> CheckTray(TPosition position);
        IAGV<TState, TPosition> Stop(int mode = 0);
    }
}
