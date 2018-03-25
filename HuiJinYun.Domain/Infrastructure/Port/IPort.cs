using System;

namespace HuiJinYun.Domain.Infrastructure.Port
{
    public class PortReceivedEventArgs : EventArgs
    {
        public byte[] Data { get; }
        public int Length { get; }

        public PortReceivedEventArgs(byte[] data, int length)
        {
            Data = data;
            Length = length;
        }
    }

    public delegate void PortReceivedEventHandler(object sender, PortReceivedEventArgs args);
    public interface IPort
    {
        IPort Read(out byte[] data, int index = 0, int length = 0);
        IPort Write(byte[] data, int index = 0, int length = 0);
        IPort Clear();

        event PortReceivedEventHandler OnReceived;
    }
}
