using Microsoft.EntityFrameworkCore;
using HotDesks.Models;

namespace HotDesks.Context;

public class DataBaseContext : DbContext
{
    public DbSet<Desk>? Desk { get; set; }
    public DbSet<Employee>? Employee { get; set; }
    public DbSet<Location>? Location { get; set; }
    public DbSet<Reservation>? Reservation { get; set; }
    
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=MyDataBase;Trusted_Connection=True;");
        }
    }
    
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Desk>()
    //         .HasMany(x => x.Reservation)
    //         .WithOne(x=>x.Location)
    //         .OnDelete(DeleteBehavior.Cascade);   
    //     
    //     modelBuilder.Entity<Employee>()
    //         .HasMany(x => x.Reservation)
    //         .WithOne(x=>x.Location)
    //         .OnDelete(DeleteBehavior.Cascade);
    //     
    //     modelBuilder.Entity<Location>()
    //         .HasMany(x => x.Desks)
    //         .WithOne(x=>x.Location)
    //         .OnDelete(DeleteBehavior.Cascade);
    //     
    //     modelBuilder.Entity<Reservation>()
    //         .HasMany(x => x.Location)
    //         .WithOne(x=>x.Employee)
    //         .OnDelete(DeleteBehavior.Cascade);
    // }

    public virtual DbSet<Desk>? Desks { get; set; } 
    public virtual DbSet<Employee>? Employees { get; set; } 
    public virtual DbSet<Location>? Locations { get; set; } 
    public virtual DbSet<Reservation>? Reservations { get; set; } 
}
