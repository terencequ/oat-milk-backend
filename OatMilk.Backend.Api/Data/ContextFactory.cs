using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace OatMilk.Backend.Api.Data
{
    /// <summary>
    ///     Only used during DB migration scaffolding
    /// </summary>
    public class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            var connectionString = GetConfig()["ConnectionStrings:MainDatabase"];

            optionsBuilder.UseSqlServer(connectionString,
                opt => opt.CommandTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds));
            return new Context(optionsBuilder.Options);
        }

        private IConfiguration GetConfig()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.${Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
                .AddJsonFile("local.settings.json", optional: true)
                .Build();
        }
    }
}