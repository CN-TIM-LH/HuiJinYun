using HuiJinYun.Domain.Log;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HuiJinYun.WD
{
    public class TcpToU3D
    {
        public event U3DPlayerReceiveMessageHandler OnReceiveMessage;
        private NamedPipeServerStream _namedPipeServer;
        private TcpClient _client;
        private bool isWhile = true;

        public TcpToU3D()
        {
            //NamedPipeListenServer svr = new NamedPipeListenServer("HuiJinYunUnity");
            //svr.Run();
            //if (null == _namedPipeServer)
            //    _namedPipeServer = new NamedPipeServerStream("HuiJinYunUnity", PipeDirection.InOut);
            try
            {
                if (null == _client)
                {
                    _client = new TcpClient();
                    _client.Connect("127.0.0.1", 8060);
                    new Thread(ReceiveThread).Start();
                }
            }
            catch (Exception ex){
                Logger.ErrorInfo("U3D", ex);
            }
        }
        protected async void ReceiveThread()
        {
            try
            {
                var buffer = new byte[1024];
                while (!_client.Connected) { }
                var stream = _client.GetStream();
                while (isWhile)
                {
                    if (!_client.Connected)
                    {
                        if (null != OnReceiveMessage)
                        {
                            int length = stream.Read(buffer, 0, buffer.Length);
                            //string data = Encoding.ASCII.GetString(buffer, 0, length);
                            string data = Encoding.Unicode.GetString(buffer, 0, length);
                            OnReceiveMessage(this, new U3DPlayerReceiveMessageEventArgs(JsonConvert.DeserializeObject(data)));
                        }
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorInfo("U3D", ex);
            }
        }
        public void SendMessage(object data) => SendMessage(JsonConvert.SerializeObject(data));

        public void SendMessage(string data)
        {
            try
            {
                if (null != _client)
                {
                    while (!_client.Connected)
                    {
                        if (null == _client)
                            _client = new TcpClient();
                        _client.Connect("127.0.0.1", 8060);
                        new Thread(ReceiveThread).Start();
                    }
                    var stream = _client.GetStream();

                    //byte[] d = Encoding.ASCII.GetBytes(data);
                    byte[] d = Encoding.Unicode.GetBytes(data);
                    stream.Write(d, 0, d.Length);
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorInfo("U3D", ex);

            }
        }
    }
}
