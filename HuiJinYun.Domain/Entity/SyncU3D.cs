using HuiJinYun.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity
{
    public class SyncU3D
    {
        public eSyncU3D type { get; set; }

        public int number { get; set; }

        public bool Operate { get; set; }

        public int Position { get; set; }

    }
}
