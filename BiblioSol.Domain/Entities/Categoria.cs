using BiblioSol.Domain.Base;

namespace BiblioSol.Domain.Entities
{
    public sealed class Categoria : AuditEntity
    {
        public int idCategoria { get; set; }
        public string descripcion { get; set; } = string.Empty;




    }
}
