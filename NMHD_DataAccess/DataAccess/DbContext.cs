using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NMHD_DataAccess.Models
{
    public class NMHDDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public NMHDDbContext(DbContextOptions<NMHDDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Gallery> Galleries { get; set; }

    }
}
