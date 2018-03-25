using System;
using System.Threading;

namespace HuiJinYun.Domain.Infrastructure.Watcher
{
    public class NotifyWatcher : IDisposable
    {
        protected INotifier _notifier;
        protected ManualResetEvent _event;
        protected NotifyArgs _args;

        public NotifyWatcher(INotifier notifier)
        {
            _notifier = notifier;
            if(null != _notifier)
            {
                _notifier.OnNotify += _notifier_OnNotify;
            }

            _event = new ManualResetEvent(false);
        }

        private void _notifier_OnNotify(object sender, NotifyArgs args)
        {
            _args = args;
            Set();
        }

        public bool Set() => _event.Set();

        public bool Reset() => _event.Reset();

        public void WaitOne(Func<object, object, bool> func)
        {
            do
            {
                _event.WaitOne();
                Reset();
            }
            while (func(_notifier, _args));
        }

        public void WaitOne(Func<object, object, bool> func, int millisecondsTimeout)
        {
            do
            {
                _event.WaitOne(millisecondsTimeout);
                Reset();
            }
            while (func(_notifier, _args));
        }

        public void Dispose()
        {
            _notifier.OnNotify -= _notifier_OnNotify;
            _notifier = null;

            _event.Close();
            _event = null;

            _args = null;

        }
    }
}
