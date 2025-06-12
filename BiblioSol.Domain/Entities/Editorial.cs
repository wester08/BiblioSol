using BiblioSol.Domain.Base;

namespace BiblioSol.Domain.Entities
{
    public sealed class Editorial : AuditEntity
    {
        public int idEditoral { get; set; }
        public string nombre { get; set; }



    }
}
