using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BiblioSol.Domain.Base;

namespace BiblioSol.Domain.Entities
{
    [Table("Libros", Schema = "Biblioteca")]
    public sealed class Libro : AuditEntity
    {
        [Key]
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
