using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Infrastructure.Data
{
    public class StoreDbContextFactory : IDesignTimeDbContextFactory<StoreContext>
    {
        public StoreContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.Development.json")
                    .Build();

            var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();

            var connectionString = configuration
                        .GetConnectionString("DefaultConnection");

            optionsBuilder.UseMySql(connectionString);

            return new StoreContext(optionsBuilder.Options);
        }
    }
}
