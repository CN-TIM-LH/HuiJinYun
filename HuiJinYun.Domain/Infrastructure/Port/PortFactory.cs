using System;

namespace HuiJinYun.Domain.Infrastructure.Port
{
    public class PortFactory
    {
        public static IPort NewPort(string port, string sparator = "://")
        {
            try
            {
                string[] ports = port.Split(new string[] { sparator }, StringSplitOptions.RemoveEmptyEntries);
                Type type = Type.GetType($"HuiJinYun.Domain.Infrastructure.Port.{ports[0]}Port");
                IPort p;
                if (null != type)
                {
                    p = (IPort)Activator.CreateInstance(type, ports[1]);
                }
                else
                {
                    type = Type.GetType($"HuiJinYun.Domain.Infrastructure.Port.PortBase");
                    p = (IPort)Activator.CreateInstance(type, port);
                }
                return p;
            }
            catch
            {

            }
            return null;
        }
    }
}
