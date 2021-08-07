using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace OatMilk.Backend.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration(config =>
                    {
                        config.AddEnvironmentVariables();
                        config.SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location));
                        config.AddJsonFile("local.settings.json", false);
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
