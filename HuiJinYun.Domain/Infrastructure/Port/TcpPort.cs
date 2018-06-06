using System;
using System.Net.Sockets;
using System.Threading;

namespace HuiJinYun.Domain.Infrastructure.Port
{
    public class TcpPort : PortBase
    {
        public override event PortReceivedEventHandler OnReceived;

        protected string _hostname;
        protected int _port;
        protected TcpClient _client;
        protected NetworkStream _stream;
        protected byte[] _buffer;

        public System.IO.Stream _debugDump;
       
        public TcpPort(string url) : this(url, bufferSize: 1000)
        { }
        public TcpPort(string url, int bufferSize = 1000) : base(url)
        {
            string[] urls = url.Split(new char[] { ':' });
            _hostname = urls[0];
            _port = int.Parse(urls[1]);
            _buffer = new byte[bufferSize];
        }
        public TcpPort(string hostname, int port, int bufferSize = 1000) : base($"{hostname}:{port}")
        {
            _hostname = hostname;
            _port = port;
            _buffer = new byte[bufferSize];
        }

        public IPort Connect()
        {
            if (null == _client)
                _client = new TcpClient();
            try
            {
                _client.Connect(_hostname, _port);
            }
            catch { }
            new Thread(ReceiveThread).Start(); 
            return this;
        }

        protected void ReceiveThread()
        {
            while (!_client.Connected) { Thread.Sleep(1000); }
            _stream = _client.GetStream();

            while (true)
            {
                if (null != OnReceived)
                {
                    int length = _stream.Read(_buffer, 0, _buffer.Length);
                    byte[] data = new byte[length];
                    Array.Copy(_buffer, data, length);
                    OnReceived(this, new PortReceivedEventArgs(data, length));
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
        }

        public override IPort Read(out byte[] data, int index = 0, int length = 0)
        {
            if (null == _client)
                Connect();
            while (null == _stream) Thread.Sleep(1);

            data = null;
            length = (0 == length ? _buffer.Length : length);
            if (null == OnReceived)
            {
                try
                {
                    lock (this)
                    {
                        int len = _stream.Read(_buffer, 0, length);
                        data = new byte[len];
                        Array.Copy(_buffer, data, len);

                        _debugDump?.Write(_buffer, 0, len);
                    }
                }
                catch { }
            }
            return this;
        }

        public override IPort Write(byte[] data, int index = 0, int length = 0)
        {
            if (null == _client)
                Connect();
            //while (true)
            //    {
            //        Connect();
            //        if (_client.Connected) break;
            //    }
            while (null == _stream) Thread.Sleep(1);
            try
            {
                if (_client.Connected)
                {
                    lock (this)
                    {
                        _stream.Write(data, 0, data.Length);
                    }
                }

            }
            catch
            { }
            return this;
        }

        public override IPort Clear()
        {
            lock (this)
            {
                int len = _stream.Read(_buffer, 0, _buffer.Length);
            }
            return this;
        }
    }
}
