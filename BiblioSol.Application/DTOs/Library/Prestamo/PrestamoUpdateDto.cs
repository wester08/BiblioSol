
namespace BiblioSol.Application.DTOs.Library.Prestamo
{
    public record PrestamoUpdateDto
    {
        public int idPrestamo { get; set; }
        public int libroId { get; set; }
        public DateOnly fechaCompromiso { get; set; }
        public DateOnly? fechaDevolucion { get; set; }
        public int diasRetraso { get; set; }
        public decimal monto { get; set; }
        public bool penalizado { get; set; }
        public int estadoId { get; set; }
        public DateTime? fechaMod{ get; set; } = DateTime.UtcNow;
        public int? usuarioMod { get; set; }
        public bool active { get; set; }
    }
}
