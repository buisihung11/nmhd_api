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
            modelBuilder.Entity<OrderDetail>().HasKey(od => new { od.OrderId, od.ProductId });
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<StoreConfig> StoreConfigs { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }

        

    }
}
