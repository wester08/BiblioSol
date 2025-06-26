
using System.ComponentModel.DataAnnotations;

namespace BiblioSol.Shared.Dtos.PrestamosDtos
{
    public record PrestamoAddDto
    {
        [Display(Name = "Cliente")]
        public string nombreCliente { get; init; }

        [Display(Name = "Libro ID")]
        public int libroId { get; init; }

        [Display(Name = "Fecha Creación")]
        public DateTime fechaCreacion { get; init; } = DateTime.UtcNow;

        [Display(Name = "Fecha Compromiso")]
        public DateOnly fechaCompromiso { get; init; }

        [Display(Name = "Estado ID")]
        public int estadoId { get; init; } = 1;

        [Display(Name = "Usuario Creación ID")]
        public int usuarioCreacionId { get; init; }

        [Display(Name = "Activo")]
        public bool active { get; init; }
    }
}
