using WebApp.Services;
using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("AppDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found.");
        builder.Services.AddRazorPages();
        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<Data.AppDbContext>();
        builder.Services.AddDbContext<MoviesDbContext>();
        builder.Services.AddDbContext<HeroesDbContext>();

        builder.Services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<Data.AppDbContext>();
        builder.Services.AddTransient<IComputerService, EFComputerService>();

        builder.Services.AddMemoryCache();
        builder.Services.AddSession();

        var app = builder.Build();

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
        app.UseMiddleware<LastVisitCookie>();

        app.UseAuthentication();
        app.UseAuthorization();
        app.UseSession();
        app.MapRazorPages();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}