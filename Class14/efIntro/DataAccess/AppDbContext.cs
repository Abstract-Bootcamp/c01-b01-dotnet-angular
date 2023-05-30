using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using efIntro.Models;

namespace efIntro.DataAccess
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DbSet<Student> Students { get; set; }

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("ConnectionString"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Student>().ToTable("Students");
        }
    }
}