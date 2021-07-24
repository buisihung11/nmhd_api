using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuocMamHongDuc_Web_App.RequestModel
{
    public class ChangePasswordModel
    {
        public String Username { get; set; }
        public String OldPassword { get; set; }
        public String NewPassword { get; set; }
    }
}
