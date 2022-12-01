using Hexagonal.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using NFTure.Core.Interfaces.Repositories;
using NFTure.Core.Interfaces.Repositories.Base;
using NFTure.Infrastructure.Data;
using NFTure.Infrastructure.Repositories;
using NFTure.Infrastructure.Repositories.Base;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

// Add services to the container.
services.AddRazorPages();

services.AddDbContext<NftureContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

services.AddScoped<INftRepository, NftRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
