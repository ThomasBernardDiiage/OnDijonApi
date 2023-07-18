using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace OnDijon.DataAccess;

public class OnDijonDbContext : DbContext
{
    private readonly string _dbConnection;
    public OnDijonDbContext(string dbConnection)
    {
        _dbConnection = dbConnection;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlServer(_dbConnection)
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}