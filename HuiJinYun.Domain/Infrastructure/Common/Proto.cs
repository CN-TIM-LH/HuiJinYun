using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Infrastructure.Common
{
    public class Proto
    {
        public static byte[] Serialize<T>(T obj) where T : IProto
        {
            List<byte> data = new List<byte>();
            Type type = typeof(T);
            PropertyInfo[] props = type.GetProperties();
            //int start = 0;

            foreach (PropertyInfo p in props)
            {
                ProtoAttribute attr = p.GetCustomAttribute<ProtoAttribute>();
                if (null == attr) continue;
                if (data.Count < (attr.Start + attr.Lenght))
                    data.AddRange(new byte[attr.Start + attr.Lenght - data.Count]);
                if (typeof(string) == p.PropertyType)
                {
                    byte[] byteArray = System.Text.Encoding.Default.GetBytes((string)p.GetValue(obj));
                    if (data.Count < (data.Count + byteArray.Length))
                        data.AddRange(new byte[byteArray.Length]);
                    for (int s = 0; s < byteArray.Count(); s++)
                    {
                        data[(data.Count- byteArray.Count()) + s] = byteArray[s];
                    }
                }
                else
                {
                    ulong temp = Convert.ToUInt64(p.GetValue(obj));
                    for (int i = 0; i < attr.Lenght; i++)
                    {
                        data[attr.Start + i] = (byte)temp;
                        temp = temp >> 8;
                    }
                }
            }
            return data.ToArray();
        }

        public static T Deserialize<T>(byte[] data) where T : IProto
        {
            Type type = typeof(T);
            T obj = Activator.CreateInstance<T>();
            PropertyInfo[] props = type.GetProperties();

            foreach (PropertyInfo p in props)
            {
                try
                {
                    ProtoAttribute attr = p.GetCustomAttribute<ProtoAttribute>();

                    if (null == attr) continue;
                    if (typeof(string) == p.PropertyType)
                    {
                        byte[] byteString = new byte[attr.Lenght];
                        Array.Copy(data, attr.Start, byteString, 0, byteString.Length);
                        string temp = Encoding.ASCII.GetString(byteString);
                        p.SetValue(obj, temp);
                    }
                    else
                    {
                        UInt32 temp = 0;
                        if (eprotoEndian.Little == attr.EndianMode)
                        {
                            for (int i = 0; i < attr.Lenght; i++)
                            {
                                temp |= ((UInt32)data[attr.Start + i] << (8 * i));
                            }
                        }
                        if (eprotoEndian.Big == attr.EndianMode)
                        {
                            for (int i = attr.Lenght - 1; i >= 0; i--)
                            {
                                temp |= ((UInt32)data[attr.Start + i] << (8 * (attr.Lenght - 1 - i)));
                            }
                        }
                        //p.SetValue(obj, Convert.ChangeType(temp, p.PropertyType));
                        switch (attr.Lenght)
                        {
                            case 1: p.SetValue(obj, (byte)temp); break;
                            case 2: p.SetValue(obj, (UInt16)temp); break;
                            case 4: p.SetValue(obj, (UInt32)temp); break;
                            default: p.SetValue(obj, temp); break;
                        }
                    }
                }
                catch
                {
                }
            }
            return obj;
        }
    }
}
