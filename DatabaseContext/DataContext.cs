using DatabaseContext.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseContext;

public class DataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\ltielbeke\\Desktop\\Application.db;Cache=Shared");
        }
    }
    
    public DbSet<SymbolicPoint> SymbolicPoints { get; set; }
    
    public DbSet<Agv> Agvs { get; set; }
}