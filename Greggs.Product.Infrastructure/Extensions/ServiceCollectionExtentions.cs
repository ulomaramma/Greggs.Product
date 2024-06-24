using Greggs.Products.Application.Interfaces.QueryBuilder;
using Greggs.Products.Application.Interfaces.Repositories;
using Greggs.Products.Infrastructure.DataAccess;
using Greggs.Products.Infrastructure.DataAccess.QueryBuilder;
using Greggs.Products.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greggs.Products.Infrastructure.Extensions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
           
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IProductQueryBuilder, ProductQueryBuilder>();


            return services;
        }
    }
}
