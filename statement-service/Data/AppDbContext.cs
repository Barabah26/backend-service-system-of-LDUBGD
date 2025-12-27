using Microsoft.EntityFrameworkCore;
using Shared.Entities;

namespace statement_service.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Statement> Statements => Set<Statement>();
    public DbSet<StatementInfo> StatementsInfo => Set<StatementInfo>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // User ↔ Statement
        modelBuilder.Entity<User>()
            .HasMany(u => u.Statements)
            .WithOne(s => s.User)
            .HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Statement ↔ StatementInfo
        modelBuilder.Entity<Statement>()
            .HasOne(s => s.StatementInfo)
            .WithOne(si => si.Statement)
            .HasForeignKey<StatementInfo>(si => si.Id);

        // Enum як string
        modelBuilder.Entity<StatementInfo>()
            .Property(si => si.StatementStatus)
            .HasConversion<string>();

        // Індекси User
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Login)
            .IsUnique();
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Name)
            .IsUnique();
    }
}
