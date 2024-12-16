using CamposDealer.Application.Services.Implementations;
using CamposDealer.Application.Services.Interfaces;
using CamposDealer.Domain.Repositories;
using CamposDealer.Persistence.Context;
using CamposDealer.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CamposDealer.Application
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CamposDealerContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CamposDealerCs")));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ISalesRepository, SaleRepository>();
            services.AddScoped<IDataRepository, DataRepository>();
        }

        public static void ConfigureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ISaleService, SalesService>();
            services.AddScoped<IDataLoaderService, DataLoaderService>();
        }

        public static void MigrationInitializer(this IApplicationBuilder serviceProvider)
        {
            using (var scope = serviceProvider.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<CamposDealerContext>();

                context.Database.Migrate();
            }
        }
    }
}