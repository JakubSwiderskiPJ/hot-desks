using Microsoft.EntityFrameworkCore;
using HotDesks.Models;

namespace HotDesks.Context;

public class DataBaseContext : DbContext
{
    public virtual DbSet<Desk>? Desks { get; set; }
    public virtual DbSet<Employee>? Employees { get; set; }
    public virtual DbSet<Location>? Locations { get; set; }
    public virtual DbSet<Reservation>? Reservations { get; set; }
    
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("DataSource=dbo.CreateDatabase.db");
        }
    }
    
}
