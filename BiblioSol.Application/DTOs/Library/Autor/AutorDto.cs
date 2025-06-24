

namespace BiblioSol.Application.DTOs.Library.Autor
{
    public record AutorDto
    {
        public int idAutor { get; init; }
        public string nombre { get; init; }
        public string apellido { get; init; }
        public DateTime fechaCreacion { get; init; }
        public int? usuarioCreacionId { get; init; }
        public DateTime? fechaMod { get; init; }
        public int? usuarioMod { get; init; }
        public bool active { get; init; }


    }
}
