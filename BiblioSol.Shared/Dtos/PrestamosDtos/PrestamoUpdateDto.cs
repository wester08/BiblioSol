using System.ComponentModel.DataAnnotations;

namespace BiblioSol.Shared.Dtos.PrestamosDtos
{
    public record PrestamoUpdateDto
    {
        [Display(Name = "ID")]
        public int idPrestamo { get; set; }

        [Display(Name = "Cliente")]
        public string nombreCliente { get; set; }

        [Display(Name = "Libro ID")]
        public int libroId { get; set; }

        [Display(Name = "Fecha Compromiso")]
        public DateOnly fechaCompromiso { get; set; }

        [Display(Name = "Fecha Devolución")]
        public DateOnly? fechaDevolucion { get; set; }

        [Display(Name = "Días de Retraso")]
        public int diasRetraso { get; set; }

        [Display(Name = "Monto")]
        public decimal monto { get; set; }

        [Display(Name = "Penalizado")]
        public bool penalizado { get; set; }

        [Display(Name = "Estado ID")]
        public int estadoId { get; set; }

        [Display(Name = "Fecha Modificación")]
        public DateTime? fechaMod { get; set; }

        [Display(Name = "Usuario Modificación ID")]
        public int? usuarioMod { get; set; }

        [Display(Name = "Activo")]
        public bool active { get; set; }
    }
}
