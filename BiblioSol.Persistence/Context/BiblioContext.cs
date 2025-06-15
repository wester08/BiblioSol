

using BiblioSol.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BiblioSol.Persistence.Context
{
    public class BiblioContext : DbContext

    {
        public BiblioContext(DbContextOptions<BiblioContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure your entities here
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        //public DbSet<Editorial> Editoriales { get; set; }
        //public DbSet<Prestamo> Prestamos { get; set; }
        //public DbSet<Autor> Autor { get; set; }
        //public DbSet<Notificacion> Notificacion { get; set; }
        //public DbSet<Usuario> Usuario { get; set; }


    }

}
