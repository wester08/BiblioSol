using BiblioSol.Domain.Base;

namespace BiblioSol.Domain.Entities
{
    public sealed class Libro : AuditEntity
    {
        public int idLibro { get; set; }
        public string titulo { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public int numeroPaginas { get; set; }
        public string isbn { get; set; } = string.Empty;
        public int autorId { get; set; }
        public int editorialId { get; set; }
        public DateOnly anioPublicacion { get; set; }
        public int categoriaId { get; set; }
        public decimal precio { get; set; }
        public int stock { get; set; }
        public int estadoId { get; set; }
        public string idioma { get; set; } = string.Empty;




    }
}
