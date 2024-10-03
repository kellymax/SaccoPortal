using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SaccoPortal.Models;

public class SaccoPortalContext : IdentityDbContext<User> // Inheriting from IdentityDbContext<User>
{
    public SaccoPortalContext(DbContextOptions<SaccoPortalContext> options) : base(options) { }

    // DbSets for other entities
    public DbSet<Member> Members { get; set; }
    public DbSet<Loan> Loans { get; set; }
    public DbSet<Contribution> Contributions { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }
    // The Roles DbSet is already defined in IdentityDbContext
    // public DbSet<Role> Roles { get; set; } // No need to define it again
    public DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => base.OnModelCreating(modelBuilder); // Important to call base method
}
