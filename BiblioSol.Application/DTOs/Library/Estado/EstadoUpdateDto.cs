

namespace BiblioSol.Application.DTOs.Library.Estado
{
    public record EstadoUpdateDto
    {
        public int idEstado { get; set; }

        public string nombre { get; set; }

        public DateTime? fechaModificacion { get; set; }
        public int? usuarioModificionId { get; set; }

        public bool active { get; set; }
    }
}
