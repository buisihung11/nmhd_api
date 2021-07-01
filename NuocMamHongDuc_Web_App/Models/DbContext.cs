using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuocMamHongDuc_Web_App.Models
{
    public class NuocMamDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public NuocMamDbContext(DbContextOptions<NuocMamDbContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
