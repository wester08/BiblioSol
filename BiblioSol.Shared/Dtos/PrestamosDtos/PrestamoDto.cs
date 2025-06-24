

namespace BiblioSol.Shared.Dtos.PrestamosDtos
{
    public record PrestamoDto
    {
        public int idPrestamo { get; set; }
        public string nombreCliente { get; set; }
        public int libroId { get; set; }
        public DateOnly fechaCompromiso { get; set; }
        public DateOnly? fechaDevolucion { get; set; }
        public int diasRetraso { get; set; }
        public decimal monto { get; set; }
        public bool penalizado { get; set; }
        public int estadoId { get; set; }
        public DateTime fechaCreacion { get; init; } = DateTime.UtcNow;
        public int usuarioCreacionId { get; init; }
        public DateTime? fechaMod { get; set; }
        public int? usuarioMod { get; set; }
        public bool active { get; set; }
    }
}
