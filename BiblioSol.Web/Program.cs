using BiblioSol.Shared.Configurations;
using BiblioSol.Shared.Interfaces;
using BiblioSol.Shared.Services;

namespace BiblioSol.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.Configure<ApiConfig>(builder.Configuration.GetSection("ApiConfig"));
            builder.Services.AddHttpClient<ICategoryHttpService, CategoryHttpService>()
                .SetHandlerLifetime(TimeSpan.FromMinutes(5));
            builder.Services.AddControllersWithViews();

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
