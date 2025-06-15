

namespace BiblioSol.Domain.Base
{
    public abstract class AuditEntity
    {
        public bool active { get; set; }
        public DateTime fechaCreacion { get; set; }
        public int usuarioCreacionId { get; set; }
        public DateTime? fechaMod { get; set; }
        public int? usuarioMod { get; set; }

    }
}
