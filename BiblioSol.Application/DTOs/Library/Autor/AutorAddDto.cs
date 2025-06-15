
namespace BiblioSol.Application.DTOs.Library.Autor
{
    public record AutorAddDto
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fechaCreacion { get; set; }
        public int usuarioCreacionId { get; set; }
        public bool active { get; set; }
    }
}
