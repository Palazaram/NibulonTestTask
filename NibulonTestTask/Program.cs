using Microsoft.EntityFrameworkCore;
using NibulonTestTask.Application.Services;
using NibulonTestTask.Core.Interfaces;
using NibulonTestTask.Persistence.Data;
using NibulonTestTask.Persistence.Repositories;

namespace NibulonTestTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<NibulonTestTaskDbContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(connectionString, sqlOption => sqlOption.MigrationsAssembly("NibulonTestTask.Persistence")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Adding DIs by Scrutor
            builder.Services.Scan(scan => scan
                .FromAssembliesOf(typeof(AUPRepository), typeof(AUPService), typeof(IAUP))
                .AddClasses(classes => classes.Where(c => c.Name.EndsWith("Repository")))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
                .AddClasses(classes => classes.Where(c => c.Name.EndsWith("Service")))
                    .AsSelf()
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
            );

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
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=AUP}/{action=AUPs}/{id?}")
                .WithStaticAssets();
            
            app.Run();
        }
    }
}
