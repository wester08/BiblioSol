using BiblioSol.Domain.Base;

namespace BiblioSol.Domain.Entities
{
    public sealed class Usuario : AuditEntity
    {
        public int usuarioId { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }


    }
}
