using LOGINPRUEBA.web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LOGINPRUEBA.web.Data;

public class DataContext(DbContextOptions<DataContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<Manager> Managers { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public DbSet<Department> Departments { get; set; }
    public DbSet<Municipality> Municipalities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>().HasIndex(x => x.UserName).IsUnique();
        modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();
        modelBuilder.Entity<User>().HasIndex(x => x.DNI).IsUnique();

        modelBuilder.Entity<Department>().HasIndex(x => x.Name).IsUnique();
        modelBuilder.Entity<Department>().HasIndex(x => x.CodDepHn).IsUnique();

        modelBuilder.Entity<Municipality>().HasIndex(x => x.CodMunHn).IsUnique();
    }
}