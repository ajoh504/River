using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;

namespace River.Infrastructure.DataAccessLayer;

public class DataContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        string apiProjectPath = Path.Combine(Directory.GetCurrentDirectory(), "../River.API");
        Assembly apiAssembly = Assembly.Load("River.API");
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(apiProjectPath)
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json")
            .AddUserSecrets(apiAssembly, optional: true)
            .Build();

        string? connectionString = configuration.GetConnectionString("DefaultConnection");
        DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}