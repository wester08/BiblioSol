using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BiblioSol.Domain.Base;

namespace BiblioSol.Domain.Entities
{
    [Table("Autores", Schema = "Biblioteca")]
    public sealed class Autor : AuditEntity
    {
        [Key]
        public int idAutor { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }



    }
}
