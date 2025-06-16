
using BiblioSol.Application.Interfaces.Respositories.Library;
using BiblioSol.Application.Interfaces.Services.Library;
using BiblioSol.Application.Services.Library;
using BiblioSol.Persistence.Context;
using BiblioSol.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BiblioSol.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<BiblioContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("BiblioConn")));

            builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository >();

            builder.Services.AddTransient<ICategoriaService, CategoryService>();

            builder.Services.AddScoped<IAutorRepository, AutorRepository>();

            builder.Services.AddTransient<IAutorService, AutorService>();

            builder.Services.AddScoped<IEditorialRepository, EditorialRepository>();   

            builder.Services.AddTransient<IEditorialSevice, EditorialService>();

            builder.Services.AddScoped<ILibroRepository, LibroRepository>();

            builder.Services.AddTransient<ILibroService, LibroService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
