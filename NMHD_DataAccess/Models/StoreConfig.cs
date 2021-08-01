using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMHD_DataAccess.Models
{
    public class StoreConfig
    {
        public StoreConfig(int id, string providerName1, string providerName2, string providerPhone1, string providerPhone2, string providerMail1, string providerMail2, DateTime startTime, DateTime endTime, string websiteURL, String footerUrl)
        {
            Id = id;
            ProviderName1 = providerName1;
            ProviderName2 = providerName2;
            ProviderPhone1 = providerPhone1;
            ProviderPhone2 = providerPhone2;
            ProviderMail1 = providerMail1;
            ProviderMail2 = providerMail2;
            StartTime = startTime;
            EndTime = endTime;
            WebsiteURL = websiteURL;
            FooterImageUrl = footerUrl;
        }

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
        public String Address { get; set; }
        public String FooterImageUrl { get; set; }


    }
}
