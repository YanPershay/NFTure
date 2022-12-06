using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using NFTure.Infrastructure.Data;
using NFTure.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddDbContext<NftureContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
services.AddApplicationServices();

var app = builder.Build();

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

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
