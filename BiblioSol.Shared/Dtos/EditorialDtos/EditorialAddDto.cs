

namespace BiblioSol.Application.DTOs.Library.Editorial
{
    public record EditorialAddDto
    {
        public string nombre { get; set; }

        public DateTime fechaCreacion { get; set; }
        public int usuarioCreacionId { get; set; }

        public bool active { get; set; }
    }
}
