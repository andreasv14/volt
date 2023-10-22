using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volt.Infrastructure.Identity;

namespace Volt.Infrastructure.Persistence;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, UserRole, Guid>
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // TODO: Add audit interceptor
        base.OnConfiguring(optionsBuilder);
    }
}
