using BiblioSol.Domain.Base;

namespace BiblioSol.Domain.Entities
{
    public sealed class Notificacion : AuditEntity
    {
        public int idNotoficacion { get; set; }
        public int prestamoId { get; set; }
        public int tipoNotificacionId { get; set; }
        public string mensaje { get; set; } = string.Empty;
        public DateTime fechaEnvio { get; set; }
        public int? plantillaId { get; set; }


    }
}
