using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NMHD_DataAccess.Models
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }
        public String ProductName { get; set; }
        public String Description { get; set; }
        public String Thumbnail { get; set; }
        public String SKU { get; set; }
        public int Position { get; set; }
        public int? GeneralProductId { get; set; }
        public int? GalleryId { get; set; }

        public ICollection<Gallery> Galleries { get; set; }
        public Product GeneralProduct { get; set; }
    }
}
