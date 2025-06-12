using BiblioSol.Domain.Base;

namespace BiblioSol.Domain.Entities
{

    public sealed class Prestamo : AuditEntity
    {

        public int idPrestamo { get; set; }
        public int libroId { get; set; }
        public DateOnly fechaCompromiso { get; set; }
        public DateOnly? fechaDevolucion { get; set; }
        public int diasRetraso { get; set; }
        public decimal monto { get; set; }
        public bool penalizado { get; set; }
        public int estadoId { get; set; }

    }
}
