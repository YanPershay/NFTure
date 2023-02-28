using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;
using NFTure.Application.Services;
using NFTure.Core.Entities.Auth;
using NFTure.Core.Interfaces;
using NFTure.Core.Interfaces.Repositories;
using NFTure.Core.Interfaces.Repositories.Base;
using NFTure.Infrastructure.Data;
using NFTure.Infrastructure.Logging;
using NFTure.Infrastructure.Repositories;
using NFTure.Infrastructure.Repositories.Base;
using NFTure.Web.Settings;
using NFTure.Web.Utils;

namespace NFTure.Web.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>()
                    .AddEntityFrameworkStores<NftureContext>()
                    .AddDefaultTokenProviders();

            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<INftRepository, NftRepository>();
            services.AddScoped<IUserActivityRepository, UserActivityRepository>();

            services.AddTransient<INftService, NftService>();
            services.AddTransient<IUserActivityService, UserActivityService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            services.AddControllers();

            services.AddApiVersioning(setup =>
            {
                setup.DefaultApiVersion = new ApiVersion(1, 0);
                setup.AssumeDefaultVersionWhenUnspecified = true;
                setup.ReportApiVersions = true;
                setup.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),
                    new HeaderApiVersionReader("x-api-version"),
                    new MediaTypeApiVersionReader("x-api-version"));
            });

            services.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.ConfigureOptions<ConfigureSwaggerOptions>();

            services.AddSwaggerGen(opts =>
            {
                opts.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description = "JWT containing userid claim",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                    });

                var security =
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Id = "Bearer",
                                    Type = ReferenceType.SecurityScheme
                                },
                                UnresolvedReference = true
                            },
                            new List<string>()
                        }
                    };

                opts.AddSecurityRequirement(security);
            });

            return services;
        }
    }
}
