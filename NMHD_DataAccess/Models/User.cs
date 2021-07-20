using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMHD_DataAccess.Models
{
    public class User
    {
        public String Username { get; set; }
        public String Password { get; set; }

        public User(String Username, String Password)
        {
            this.Username = Username;
            this.Password = Password;
        }
    }
}
