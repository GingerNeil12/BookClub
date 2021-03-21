using System.Reflection;
using BookClub.Catalog.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace BookClub.Catalog
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCatalog
        (
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            _ = services.AddDbContext<CatalogDbContext>
            (
                options => options.UseSqlServer(configuration.GetConnectionString("Default"))
            );

            _ = services.AddTransient<ICatalogDbContext, CatalogDbContext>();

            _ = services.Scan
            (
                scan => scan
                    .FromCallingAssembly()
                    .AddClasses()
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithTransientLifetime()
            );

            _ = services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
