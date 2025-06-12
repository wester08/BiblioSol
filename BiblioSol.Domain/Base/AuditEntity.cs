

namespace BiblioSol.Domain.Base
{
    public abstract class AuditEntity
    {
        public bool isActive { get; set; }
        public DateTime fechaCreacion { get; set; }
        public int usuarioCrecaion { get; set; }
        public DateTime? fechaModificacion { get; set; }
        public int? usuarioModificacionId { get; set; }

    }
}
