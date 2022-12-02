using Microsoft.EntityFrameworkCore;
using NFTure.Infrastructure.Data;
using NFTure.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

// Add services to the container.
services.AddRazorPages();

services.AddControllers();

services.AddDbContext<NftureContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

services.AddApplicationServices();

services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
