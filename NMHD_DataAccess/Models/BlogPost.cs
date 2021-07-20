using NMHD_DataAccess.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMHD_DataAccess.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Banner{ get; set; }

        public String Content { get; set; }
        public BlogPostType BlogPostType { get; set; }

    }
}
