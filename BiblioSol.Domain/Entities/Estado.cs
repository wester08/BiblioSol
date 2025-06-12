using BiblioSol.Domain.Base;

namespace BiblioSol.Domain.Entities
{
    public sealed class Estado : AuditEntity
    {
        public int idEstado { get; set; }
        public string nombre { get; set; }


    }
}
