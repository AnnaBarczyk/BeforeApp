using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BeforeApp.Data
{
    public class BeforeAppContextFactory : IDesignTimeDbContextFactory<BeforeAppContext>
    {
        public BeforeAppContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            return new BeforeAppContext(new DbContextOptionsBuilder<BeforeAppContext>().Options, config);
        }
    }
}