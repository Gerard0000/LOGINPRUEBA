using LoginPrueba.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoginPrueba.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Department> Departments { get; set; }
    public DbSet<Municipality> Municipalities { get; set; }
    public DbSet<Court> Courts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Department>().HasIndex(x => x.Name).IsUnique();
        modelBuilder.Entity<Department>().HasIndex(x => x.CodDepHn).IsUnique();

        modelBuilder.Entity<Municipality>().HasIndex(x => x.CodMunHn).IsUnique();

        modelBuilder.Entity<Court>().HasIndex(x => x.Name).IsUnique();
    }
}