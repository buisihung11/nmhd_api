using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NMHD_DataAccess.Models
{
    public class Gallery : BaseEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImageURL { get; set; }
        public Product Product { get; set; }
    }
}
