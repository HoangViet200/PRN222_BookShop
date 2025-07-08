using Microsoft.EntityFrameworkCore;
using PRN222_BookShop.DA;
using PRN222_BookShop.Models;
using PRN222_BookShop.Services;

namespace PRN222_DreamsCar
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<DBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDatabase")));

            
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ICategoryDA, CategoryDASQLServer>();
            builder.Services.AddScoped<ICategoryServices, CategoryServices>();
            builder.Services.AddScoped<IPublisherDA, PublisherDASQLServer>();
            builder.Services.AddScoped<IPublisherServices, PublisherServices>();
            builder.Services.AddScoped<IAuthorDA, AuthortDASQLServer>();
            builder.Services.AddScoped<IAuthorServices, AuthorServices>();
            builder.Services.AddScoped<ISupplierDA, SupplierDASQLServer>();
            builder.Services.AddScoped<ISupplierServices, SupplierServices>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
