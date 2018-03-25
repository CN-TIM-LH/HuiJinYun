using HuiJinYun.Domain.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.PLC
{
    public enum eRemoteRunMode : UInt32
    {
        Normal = 0x00000001,
        Force = 0x00000003,
    }

    public class RemoteRunCommand : PlcCommandBase
    {
        [Proto(15, 4)]
        public eRemoteRunMode Mode { get; set; }
        public RemoteRunCommand(eRemoteRunMode mode = eRemoteRunMode.Normal) : base(ePlcInstructions.RemoteReset, 4)
        {
            Mode = mode;
        }
    }
}
