using DatabaseContext.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DatabaseContext;

public class DataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=Application.db;Cache=Shared");
        }
    }
    
    public DbSet<SymbolicPoint> SymbolicPoints { get; set; }
    
    public DbSet<Agv> Agvs { get; set; }
}