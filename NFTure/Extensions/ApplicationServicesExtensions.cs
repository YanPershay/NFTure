using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Versioning;
using NFTure.Application;
using NFTure.Application.Services;
using NFTure.Core.Interfaces.Repositories;
using NFTure.Core.Interfaces.Repositories.Base;
using NFTure.Infrastructure.Repositories;
using NFTure.Infrastructure.Repositories.Base;

namespace NFTure.Web.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<INftRepository, NftRepository>();
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddTransient<INftService, NftService>();

            // TODO: observe how to use it fully
            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                o.ReportApiVersions = true;
                o.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader("api-version"),
                    new HeaderApiVersionReader("X-Version"),
                    new MediaTypeApiVersionReader("ver"));
            });

            return services;
        }
    }
}
