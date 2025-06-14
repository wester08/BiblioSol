using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BiblioSol.Domain.Base;

namespace BiblioSol.Domain.Entities
{
    [Table("Categorias", Schema = "Biblioteca")]
    public sealed class Categoria : AuditEntity
    {
        [Key]
        public int idCategoria { get; set; }
        public string descripcion { get; set; } = string.Empty;




    }
}
