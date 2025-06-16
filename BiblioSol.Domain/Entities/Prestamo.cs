using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BiblioSol.Domain.Base;

namespace BiblioSol.Domain.Entities
{
    [Table("Prestamos", Schema = "Biblioteca")]
    public sealed class Prestamo : AuditEntity
    {
        [Key]
        public int idPrestamo { get; set; }

        public string nombreCliente { get; set; }
        public int libroId { get; set; }
        public DateOnly fechaCompromiso { get; set; }
        public DateOnly? fechaDevolucion { get; set; }
        public int diasRetraso { get; set; }
        public decimal monto { get; set; }
        public bool penalizado { get; set; }
        public int estadoId { get; set; }

    }
}
