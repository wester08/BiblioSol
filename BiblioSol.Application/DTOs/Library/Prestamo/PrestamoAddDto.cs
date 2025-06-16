

namespace BiblioSol.Application.DTOs.Library.Prestamo
{
    public record PrestamoAddDto
    {
        public int libroId { get; init; }
        public string nombreCliente { get; init; } 
        public DateOnly fechaCompromiso { get; init; }
        public int estadoId { get; init; }
        public DateTime fechaCreacion { get; init; } = DateTime.UtcNow;
        public int usuarioCreacionId { get; init; }
        public bool active { get; init; }
    }
}
