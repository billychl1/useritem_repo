using HealthAPI.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.DataAnnotations;

namespace HealthAPI.Data
{public class HealthContext : DbContext {
    public HealthContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder) {
        builder.Entity<property>().Property(p => p.name).HasMaxLength(45);
        builder.Entity<item>().Property(p => p.name).HasMaxLength(45);
        builder.Entity<user>().Property(p => p.username).HasMaxLength(45);

        builder.Entity<property>().ToTable("property");
        builder.Entity<item>().ToTable("item");
        builder.Entity<user>().ToTable("user");
    }

    public DbSet<property> propertys { get; set; }
    public DbSet<item> items { get; set; }
    public DbSet<user> users { get; set; }
}

}