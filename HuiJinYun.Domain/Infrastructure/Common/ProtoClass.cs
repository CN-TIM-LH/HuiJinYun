using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Infrastructure.Common
{
    public class ProtoClass : ISerialize
    {
        public T Deserialize<T>(byte[] data) where T : IProto
        {
            return Proto.Deserialize<T>(data);
        }

        public byte[] Serialize<T>(T obj) where T : IProto
        {
            return Proto.Serialize<T>(obj);
        }
    }
}
