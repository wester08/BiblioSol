using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BiblioSol.Domain.Base;

namespace BiblioSol.Domain.Entities
{
    [Table("Editoriales", Schema = "Biblioteca")]
    public sealed class Editorial : AuditEntity
    {
        [Key]
        public int idEditorial { get; set; }
        public string nombre { get; set; }



    }
}
