using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity
{
    public class AGVCar
    {
        /// <summary>
        /// 编号
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// agv小车编号
        /// </summary>
        public int CarNumber { get; set; }
        /// <summary>
        /// 绑定IP
        /// </summary>
        public string BindIP { get; set; }

        /// <summary>
        /// 绑定端口
        /// </summary>
        public string Port { get; set; }
        /// <summary>
        /// 是否启用 {启用:True 禁用：fale}
        /// </summary>
        public bool Enable { get; set; }

        /// <summary>
        /// 是否连接
        /// </summary>
        public bool IsConnection { get; set; }

    }
}
