using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntroToEf.Models;
using Microsoft.EntityFrameworkCore;

namespace IntroToEf.DataAccess
{
    public class EfDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseNpgsql(
                "Host=localhost;port=5433;Database=w5c14;Username=postgres;Password=123456;IncludeErrorDetail=true;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>().ToTable("Employees");
        }
    }
}