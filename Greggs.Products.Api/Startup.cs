using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Greggs.Products.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Greggs.Products.Application.Services;
using Greggs.Products.Application.Interfaces.Services;
using Greggs.Products.Application.Helpers;
using Greggs.Products.Application.Interfaces.Helpers;
using Greggs.Products.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
namespace Greggs.Products.Api;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddInfrastructureServices(Configuration);
        services.AddControllers();
        services.AddScoped<IProductService,ProductService>();
        services.AddScoped<ICurrencyConversionHelper, CurrencyConversionHelper>();
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSwagger();
        app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Greggs Products API V1"); });

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        // Apply migrations at startup
        ApplyMigrations(app);
    }
    private void ApplyMigrations(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();
        }
    }

}