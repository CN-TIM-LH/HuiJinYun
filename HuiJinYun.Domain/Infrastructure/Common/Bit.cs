using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Infrastructure.Common
{
    public class Bit
    {
        #region Normal Type
        public static byte Set(byte data, byte bit) => (byte)(data | bit);
        public static byte Clr(byte data, byte bit) => (byte)(data & ~bit);

        public static short Set(short data, short bit) => (short)(data | bit);
        public static short Clr(short data, short bit) => (short)(data & ~bit);
        public static int Set(int data, int bit) => data | bit;
        public static int Clr(int data, int bit) => data & ~bit;
        public static long Set(long data, long bit) => data | bit;
        public static long Clr(long data, long bit) => data & ~bit;

        public static ushort Set(ushort data, ushort bit) => (ushort)(data | bit);
        public static ushort Clr(ushort data, ushort bit) => (ushort)(data & ~bit);
        public static uint Set(uint data, uint bit) => data | bit;
        public static uint Clr(uint data, uint bit) => data & ~bit;
        public static ulong Set(ulong data, ulong bit) => data | bit;
        public static ulong Clr(ulong data, ulong bit) => data & ~bit;
        #endregion

        #region Generic Type
        public static T Set<T>(T data, T bit)
        {
            var t = typeof(T);
            if (!t.IsValueType)
                throw new Exception();

            var d = (UInt64)Convert.ChangeType(data, typeof(UInt64));
            var b = (UInt64)Convert.ChangeType(bit, typeof(UInt64));
            d |= b;

            if (t.IsEnum)
                return (T)System.Enum.ToObject(t, d);
            return (T)Convert.ChangeType(d, t); ;
        }

        public static T Clr<T>(T data, T bit)
        {
            var t = typeof(T);
            if (!t.IsValueType)
                throw new Exception();

            var d = (UInt64)Convert.ChangeType(data, typeof(UInt64));
            var b = (UInt64)Convert.ChangeType(bit, typeof(UInt64));
            d &= ~b;

            if (t.IsEnum)
                return (T)System.Enum.ToObject(t, d);
            return (T)Convert.ChangeType(d, t); ;
        }

        public static bool Tst<T>(T data, T bit)
        {
            var t = typeof(T);
            if (!t.IsValueType)
                throw new Exception();

            var d = (UInt64)Convert.ChangeType(data, typeof(UInt64));
            var b = (UInt64)Convert.ChangeType(bit, typeof(UInt64));
            return (d & b) == b;
        }
        #endregion
    }
}
