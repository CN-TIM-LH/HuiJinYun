using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Infrastructure.Common
{
    public enum eprotoEndian
    {
        Little,
        Big
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ProtoAttribute : Attribute
    {
        public int Start { get; protected set; }
        public int Lenght { get; set; } = 1;
        public eprotoEndian EndianMode { get; set; } = eprotoEndian.Little;

        public ProtoAttribute(int start) : this(start, 1) { }

        public ProtoAttribute(int start,int lenght)
        {
            Start = start;
            Lenght = lenght;
        }
    }
}
