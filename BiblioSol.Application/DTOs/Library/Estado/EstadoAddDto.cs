namespace BiblioSol.Application.DTOs.Library.Estado
{
    public record EstadoAddDto
    {
        public string nombre { get; init; }

        public DateTime fechaCreacion { get; init; }

        public int usuarioCreacionId { get; init; }
        public bool active { get; init; } = true;

    }
}
