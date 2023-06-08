using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PcPartsShowRoom.Models;

namespace PcPartsShowRoom.DataAccess
{
    public class PartsContext : DbContext
    {
        public DbSet<Part> Parts { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseNpgsql(
                "Host=localhost;port=5433;Database=PcParts;Username=postgres;Password=123456;IncludeErrorDetail=true;");
        }
    }
}
