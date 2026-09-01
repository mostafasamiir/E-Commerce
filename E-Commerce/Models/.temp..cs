using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace E_Commerce.Models
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory();
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var conn = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(conn);
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
