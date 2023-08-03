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


    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        // var userId = _currentUserService.UserId;

        foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    // entry.Entity.CreatedBy = userId;
                    entry.Entity.Created = DateTime.UtcNow;
                    entry.Entity.LastModified = DateTime.UtcNow;
                    break;

                case EntityState.Modified:
                    // entry.Entity.LastModifiedBy = userId;
                    entry.Entity.LastModified = DateTime.UtcNow;
                    break;
            }
        }


        var result = await base.SaveChangesAsync(cancellationToken);


        return result;
    }
}

