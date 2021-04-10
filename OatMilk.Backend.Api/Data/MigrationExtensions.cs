using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OatMilk.Backend.Api.Data
{
    public static class MigrationExtensions
    {

        /// <summary>
        /// Attempt to migrate the database using EF Core's database migrations system.
        /// </summary>
        /// <typeparam name="TContext"></typeparam>
        /// <param name="host"></param>
        /// <returns></returns>
        public static IHost MigrateDbContext<TContext>(
            this IHost host)
            where TContext : DbContext
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<TContext>();

                context.Database.Migrate();
            }
            return host;
        }
    }
}
