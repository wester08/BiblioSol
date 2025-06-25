

namespace BiblioSol.Shared.Dtos.LibrosDtos
{
    public record LibroDto
    {
        public int idLibro { get; set; }
        public string titulo { get; set; }

        public string descripcion { get; set; }
        public int numeroPaginas { get; set; }
        public string isbn { get; set; }
        public int autorId { get; set; }
        public int editorialId { get; set; }
        public DateOnly anioPublicacion { get; set; }
        public int categoriaId { get; set; }
        public decimal precio { get; set; }
        public int stock { get; set; }
        public int estadoId { get; set; }
        public string idioma { get; set; }
        public DateTime fechaCreacion { get; set; }
        public int usuarioCreacionId { get; set; }
        public DateTime? fechaMod { get; set; }
        public int? usuarioMod { get; set; }
        public bool active { get; set; }
    }
}
