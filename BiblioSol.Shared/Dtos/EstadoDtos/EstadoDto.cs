

namespace BiblioSol.Shared.Dtos.EstadoDtos
{
    public record EstadoDto
    {
        public int idEstado { get; set; }
        public string nombre { get; set; }
        public DateTime fechaCreacion { get; set; }
        public int usuarioCreacionId { get; set; }
        public DateTime? fechaMod { get; set; }
        public int? usuarioMod { get; set; }
        public bool active { get; set; }

        
    }
}
