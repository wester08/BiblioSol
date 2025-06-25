namespace BiblioSol.Shared.Dtos.EstadoDtos
{
    public record EstadoAddDto
    {
        public string nombre { get; init; }

        public DateTime fechaCreacion { get; init; }

        public int usuarioCreacionId { get; init; }
        public bool active { get; init; } = true;

    }
}
