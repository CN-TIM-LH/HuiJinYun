using System;

namespace HuiJinYun.Domain.Infrastructure.Port
{
    public class PortBase : IPort
    {
        public virtual event PortReceivedEventHandler OnReceived;

        private string _port;
        public virtual string Port
        {
            get
            {
                return _port;
            }
            set
            {
                _port = value;
            }
        }
        public PortBase(string port)
        {
            _port = port;
        }

        public virtual IPort Read(out byte[] data, int index = 0, int length = 0)
        {
            throw new NotImplementedException();
        }

        public virtual IPort Write(byte[] data, int index = 0, int length = 0)
        {
            throw new NotImplementedException();
        }

        public virtual IPort Clear()
        {
            throw new NotImplementedException();
        }
    }
}
