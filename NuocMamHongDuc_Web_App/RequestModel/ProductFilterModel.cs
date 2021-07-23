using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuocMamHongDuc_Web_App.RequestModel
{
    public class ProductFilterModel
    {
        public bool IsParent { get; set; }
        public String[] Tags { get; set; }
        public int ProductId { get; set; }
        public int GeneralProductId { get; set; }


    }
}
