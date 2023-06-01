using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeesManager.Models;

namespace EmployeesManager.DataAccess
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Job> Jobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseNpgsql(
                "Host=localhost;port=5433;Database=EmployeeManager;Username=postgres;Password=123456;IncludeErrorDetail=true;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // builder.Entity<Employee>().ToTable("Employees");
        }
    }
}