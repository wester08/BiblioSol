using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BiblioSol.Domain.Base;

namespace BiblioSol.Domain.Entities
{
    [Table("Estados", Schema = "Biblioteca")]
    public sealed class Estado : AuditEntity
    {
        [Key]
        public int idEstado { get; set; }
        public string nombre { get; set; }


    }
}
