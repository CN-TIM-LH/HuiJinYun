using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Enum
{
    public enum eHuiJinYunStagePosition
    {
        Null,
        /// <summary>
        /// 初始化
        /// </summary>
        Initial,
        /// <summary>
        /// 解胶
        /// </summary>
        Peptization,
        /// <summary>
        /// 包胶
        /// </summary>
        Encapsulation,
        /// <summary>
        /// 缠绕
        /// </summary>
        Enlace,
        /// <summary>
        /// 硫化
        /// </summary>
        Vulcanization,
        /// <summary>
        /// 结束
        /// </summary>
        Finish,
        OnGoing = 0x01 << 8
    }
}
