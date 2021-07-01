using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NMHD_DataAccess.Models
{
    public class BaseEntity
    {
        public bool? Active { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
