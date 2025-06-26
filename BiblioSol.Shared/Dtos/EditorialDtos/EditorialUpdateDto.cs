

namespace BiblioSol.Application.DTOs.Library.Editorial
{
    public record EditorialUpdateDto
    {
        public int idEditorial { get; set; }
        public string nombre { get; set; }
        public DateTime? fechaMod{ get; set; }
        public int? usuarioMod { get; set; }
        public bool active { get; set; }


    }
}
