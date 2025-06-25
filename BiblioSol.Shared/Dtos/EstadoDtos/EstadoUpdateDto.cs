

namespace BiblioSol.Shared.Dtos.EstadoDtos
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
