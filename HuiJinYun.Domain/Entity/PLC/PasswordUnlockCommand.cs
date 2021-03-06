﻿using HuiJinYun.Domain.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.PLC
{
    public class PasswordUnlockCommand : PlcCommandBase
    {
        [Proto(15, 2)]
        public UInt16 PasswordLength { get; set; }

        [Proto(17)]
        public string Password { get; set; }
        
        public PasswordUnlockCommand(string password) :
            base(ePlcInstructions.PasswordUnlock, (UInt16)(password.Length + 2))
        {
            PasswordLength = (UInt16)password.Length;
            Password = password;
        }
    }
}
