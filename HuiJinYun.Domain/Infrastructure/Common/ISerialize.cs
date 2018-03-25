using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Infrastructure.Common
{
    public interface ISerialize
    {
        byte[] Serialize<T>(T obj) where T : IProto;
        T Deserialize<T>(byte[] data) where T : IProto;
    }
}
