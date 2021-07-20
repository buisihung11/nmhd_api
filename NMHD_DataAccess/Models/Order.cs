using NMHD_DataAccess.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMHD_DataAccess.Models
{

    public class Order : BaseEntity
    {
        public int Id { get; set; }
        public DateTime CheckInDate { get; set; }
        public String CustName { get; set; }
        public String CustPhone { get; set; }
        public String CustEmail { get; set; }
        public String Note { get; set; }
        public OrderStatus Status { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
