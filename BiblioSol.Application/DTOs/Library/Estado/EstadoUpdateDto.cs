

namespace BiblioSol.Application.DTOs.Library.Estado
{
    public record EstadoUpdateDto
    {
        public int idEstado { get; set; }

        public string nombre { get; set; }

        public DateTime? fechaMod { get; set; }
        public int? usuarioMod { get; set; }

        public bool active { get; set; }
    }
}
