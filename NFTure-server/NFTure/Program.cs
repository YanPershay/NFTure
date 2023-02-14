using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using NFTure.Infrastructure.Data;
using NFTure.Web.Extensions;
using NLog;
using NLog.Web;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    var services = builder.Services;

    services.AddDbContext<NftureContext>(opts =>
    {
        opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        opts.EnableSensitiveDataLogging();
    });

    services.AddApplicationServices();

    var app = builder.Build();

    var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

    SeedDatabase(app);

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var groupName in apiVersionDescriptionProvider
                                  .ApiVersionDescriptions
                                  .Reverse()
                                  .Select(d => d.GroupName))
        {
            options.SwaggerEndpoint($"/swagger/{groupName}/swagger.json",
                groupName.ToUpperInvariant());
        }
    });

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    logger.Error(typeof(Program).ToString(), ex);
    throw;
}
finally
{
    LogManager.Shutdown();
}

// TODO: move to utils static class
static void SeedDatabase(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();

    try
    {
        var context = services.GetRequiredService<NftureContext>();
        NftureContextSeed.SeedAsync(context, loggerFactory).Wait();
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex.Message, "An error occured DB seeding.");
    }
}
