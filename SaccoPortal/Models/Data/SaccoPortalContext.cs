using Microsoft.EntityFrameworkCore;
using SaccoPortal.Models;

public class SaccoPortalContext : DbContext
{
    public SaccoPortalContext(DbContextOptions<SaccoPortalContext> options) : base(options) { }

    public DbSet<Member> Members { get; set; }
    public DbSet<Loan> Loans { get; set; }
    public DbSet<Contribution> Contributions { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Loan>()
            .HasOne(l => l.Member)
            .WithMany(m => m.Loans)
            .HasForeignKey(l => l.MemberId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Contribution>()
            .HasOne(c => c.Member)
            .WithMany(m => m.Contributions)
            .HasForeignKey(c => c.MemberId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
