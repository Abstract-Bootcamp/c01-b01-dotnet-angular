using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PcPartsManager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PcPartsManager;

public class ApplicationContext : IdentityDbContext<User>
{
    public DbSet<Part> Parts { get; set; }
    public DbSet<SubCategory> SubCategories { get; set; }
    public DbSet<Category> Categories { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
}

