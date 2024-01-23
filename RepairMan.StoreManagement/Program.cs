
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RepairMan.StoreManagement;
using RepairMan.StoreManagement.Application.Contract.Interfaces.Categories;
using RepairMan.StoreManagement.Application.Contract.Interfaces.Parts;
using RepairMan.StoreManagement.Application.Services.Categories;
using RepairMan.StoreManagement.Application.Services.Parts;
using RepairMan.StoreManagement.Data;
using RepairMan.StoreManagement.Data.Repository.Categories;
using RepairMan.StoreManagement.Data.Repository.Parts;
using RepairMan.StoreManagement.Domain.Categories;
using RepairMan.StoreManagement.Domain.Parts;
using RepairMan.StoreManagement.Localization;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(b =>
    {
        b.RegisterModule(new AutofacModule());
    });

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IConfigurationRoot>(builder.Configuration);

builder.Services.AddScoped<IPartRepository, PartRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IPartService, PartService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddDbContext<RepairManStoreManagementDbContext>(options =>
{
    //options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString"));
});

var app = builder.Build();

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<RepairManStoreManagementDbContext>();
    context.Database.Migrate();
}

//var config = new ConfigurationBuilder()
//            .AddJsonFile("appsettings.json", false)
//            .Build();
//var settings = config.GetSection("ApplicationSettings").Get<ApplicationSettingsModel>();
//config.Bind(settings);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
