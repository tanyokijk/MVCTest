using Microsoft.EntityFrameworkCore;
using MVC.Interfaces;
using MVC.Models;
using MVC.Repository;

namespace MVC;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);


        builder.Configuration.SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("dbSettings.json").Build();
        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddTransient<IAllCars, CarRepository>();
        builder.Services.AddTransient<ICarsCategory, CategoryRepository>();
        builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddTransient<IAllOrders, OrdersRepository>();

        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        builder.Services.AddScoped(sp => ShopCart.GetCart(sp));

        //builder.Services.AddMvc();

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
        app.UseSession();

        app.UseRouting();

        app.UseAuthorization();

        using (var scope = app.Services.CreateScope())
        {
            AppDBContext context = scope.ServiceProvider.GetRequiredService<AppDBContext>();
            DBObjects.Initial(context);
        }

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            endpoints.MapControllerRoute(
                name: "categoryFilter",
                pattern: "{controller=Car}/{action}/{category?}",
                defaults: new { controller = "Car", action = "List" });
            endpoints.MapControllerRoute(
                name: "complete",
                pattern: "Order/Complete",
                defaults: new { controller = "Order", action = "Complete" }
);
        });

        /*app.UseMvc(routes =>
        {
            routes.MapRoute(name: "default", template: "{controller=Home}/{action}/{id?}");
            routes.MapRoute(name: "categoryFilter", template: "{controller=Car}/{action}/{category?}", defaults: new { Controller = "Car", action = "List" });
        });*/


        /*app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");*/

        app.Run();
    }
}
