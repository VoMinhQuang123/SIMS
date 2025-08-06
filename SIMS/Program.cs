using Microsoft.EntityFrameworkCore;
using SIMS.BDContext;
using SIMS.Interface;
using SIMS.Repository;
using SIMS.Service;

namespace SIMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure database with EntityFramework
            builder.Services.AddDbContext<SIMSDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("default")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ILogin, LoginRepository>();
            builder.Services.AddScoped<Login_Service>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            //app.MapControllerRoute(
            //    name: "admin",
            //    pattern: "admin/{controller=Dashboard_Admin}/{action=Index}/{id?}");

            //app.MapControllerRoute(
            //    name: "teacher",
            //    pattern: "teacher/{controller=Dashboard_Teacher}/{action=Index}/{id?}");

            //app.MapControllerRoute(
            //    name: "student",
            //    pattern: "student/{controller=Dashboard_Student}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                //pattern: "{controller=Dashboard_Admin}/{action=Index}/{id?}")
                pattern: "{controller=Dashboard_Teacher}/{action=Index}/{id?}")
                //pattern: "{controller=Dashboard_Student}/{action=Index}/{id?}")
                //pattern: "{controller=Login}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
