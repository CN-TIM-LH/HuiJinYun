using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity
{
  public  class PlcEntity
    {
        public string Id { get; set; }
        public string Device { get; set; }
        public string Ip { get; set; }
        public string Port { get; set; }
        
        public string Enable { get; set; }
        public string IsConnect { get; set; }
    }
}
