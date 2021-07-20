using NMHD_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMHD_DataAccess.ViewModels
{
    public class ProductDTO : Product
    {
        public ProductDTO(Product ch)
        {
            foreach (var prop in ch.GetType().GetProperties())
            {
                this.GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(ch, null), null);
            }
        }
        public List<Product> ChildProducts { get; set; }
    }
}
