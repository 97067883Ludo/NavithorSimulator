using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DatabaseContext.Factories;

public class DataContextFactory : IDataContextFactory
{
    private readonly IServiceProvider _serviceProvider;

    public DataContextFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public DataContext CreateDbContext()
    {
        // Option 1: Resolve DbContextOptions from the service provider
        return new DataContext();

        // Option 2: If you need more control over the creation, you can build the options here
        // var optionsBuilder = new DbContextOptionsBuilder<DataContext.DataContext>();
        // // Configure your database connection here (e.g., from configuration)
        // optionsBuilder.UseSqlServer("YourConnectionString");
        // return new DataContext.DataContext(optionsBuilder.Options);
    }
}

public interface IDataContextFactory
{
    DataContext CreateDbContext();
}