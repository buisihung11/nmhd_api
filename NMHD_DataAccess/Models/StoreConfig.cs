using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMHD_DataAccess.Models
{
    public class StoreConfig
    {
        public int Id { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String ProviderName1 { get; set; }
        public String ProviderName2 { get; set; }
        public String ProviderPhone1 { get; set; }
        public String ProviderPhone2 { get; set; }
        public String ProviderMail1 { get; set; }
        public String ProviderMail2 { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public String WebsiteURL { get; set; }

    }
}
