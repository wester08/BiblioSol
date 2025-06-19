

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BiblioSol.Domain.Base;

namespace BiblioSol.Domain.Entities
{
    [Table("Dashboard", Schema = "Biblioteca")]
    public class Dashboard : AuditEntity
    {
        [Key]
        public int idActividad { get; set; }
        public string AccionRealizada { get; set; }
        public string Descripcion { get; set; }


    }
}
