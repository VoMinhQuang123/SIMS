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
            // Register service and repository
            // Login
            builder.Services.AddScoped<ILogin, Repository_Login>();
            builder.Services.AddScoped<Service_Login>();
            // Admin
            builder.Services.AddScoped<IAdmin, Repository_Admin>();
            builder.Services.AddScoped<Service_Admin>();
            // User
            builder.Services.AddScoped<IUser, Repository_User>();
            builder.Services.AddScoped<Service_User>();
            // Student
            builder.Services.AddScoped<IStudent, Repository_Student>();
            builder.Services.AddScoped<Service_Student>();
            // Teacher
            builder.Services.AddScoped<ITeacher, Repository_Teacher>();
            builder.Services.AddScoped<Service_Teacher>();
            // Class
            builder.Services.AddScoped<IClass, Repository_Class>();
            builder.Services.AddScoped<Service_Class>();
            // Course
            builder.Services.AddScoped<ICourse, Repository_Course>();
            builder.Services.AddScoped<Service_Course>();
            // Type
            builder.Services.AddScoped<IType, Repository_Type>();
            builder.Services.AddScoped<Service_Type>();
            // Semester
            builder.Services.AddScoped<ISemester, Repository_Semester>();
            builder.Services.AddScoped<Service_Semester>();
            // TeachingAssignment
            builder.Services.AddScoped<ITeachingAssignment, Repository_TeachingAssignment>();
            builder.Services.AddScoped<Service_TeachingAssignment>();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(24);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

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
            app.UseSession();

            app.MapStaticAssets();

            app.MapControllerRoute(
                name: "default",
                //pattern: "{controller=Dashboard_Admin}/{action=Index}/{id?}")
                //pattern: "{controller=Dashboard_Teacher}/{action=Index}/{id?}")
                //pattern: "{controller=Dashboard_Student}/{action=Index}/{id?}")
                pattern: "{controller=Login}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
