using BiblioSol.Domain.Base;

namespace BiblioSol.Domain.Entities
{
    public sealed class Autor : AuditEntity
    {

        public int idAutor { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }



    }
}
