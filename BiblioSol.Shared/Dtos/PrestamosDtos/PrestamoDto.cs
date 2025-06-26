

using System.ComponentModel.DataAnnotations;

namespace BiblioSol.Shared.Dtos.PrestamosDtos
{
    public record PrestamoDto
    {
        [Display(Name = "ID")]
        public int idPrestamo { get; set; }
        [Display(Name = "Cliente")]
        public string nombreCliente { get; set; }
        [Display(Name = "Libro ID")]
        public int libroId { get; set; }
        [Display(Name = "Fecha Creacion")]
        public DateTime fechaCreacion { get; init; } = DateTime.UtcNow;
        [Display(Name = "Fecha Compromiso")]
        public DateOnly fechaCompromiso { get; set; }
        [Display(Name = "Fecha Devolucion")]
        public DateOnly? fechaDevolucion { get; set; }
        [Display(Name = "Dias Retraso")]
        public int diasRetraso { get; set; }

        [Display(Name = "Monto")]
        public decimal monto { get; set; }
        [Display(Name = "Penalizado")]
        public bool penalizado { get; set; }
        [Display(Name = "Estado ID")]
        public int estadoId { get; set; }
        [Display(Name = "Usuario Creacion ID")]
        public int usuarioCreacionId { get; init; }
        [Display(Name = "Fecha Modificacion")]
        public DateTime? fechaMod { get; set; }
        [Display(Name = "Usuario Modificacion ID")]
        public int? usuarioMod { get; set; }
        [Display(Name = "Activo")]
        public bool active { get; set; }
    }
}
