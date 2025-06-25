

namespace BiblioSol.Shared.Dtos.PrestamosDtos
{
    public record PrestamoAddDto
    {

        public string nombreCliente { get; init; }
        public int libroId { get; init; }
        public DateTime fechaCreacion { get; init; } = DateTime.UtcNow;
        public DateOnly fechaCompromiso { get; init; }

        public int estadoId { get; init; } = 1;

        public int usuarioCreacionId { get; init; }
        public bool active { get; init; }
    }
}
