using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BiblioSol.Domain.Base;

namespace BiblioSol.Domain.Entities
{
    [Table("Notificaciones", Schema = "Biblioteca")]
    public sealed class Notificacion : AuditEntity
    {
        [Key]
        public int idNotificacion { get; set; }
        public int prestamoId { get; set; }
        public int tipoNotificacionId { get; set; }
        public string mensaje { get; set; } = string.Empty;
        public DateTime fechaEnvio { get; set; }
        public int? plantillaId { get; set; }


    }
}
