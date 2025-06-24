

namespace BiblioSol.Shared.Dtos
{
    public record CategoryDto
    {
        public int idCategoria { get; set; }
        public string descripcion { get; set; } = string.Empty;
        public DateTime fechaCreacion { get; set; }
        public int usuarioCreacionId { get; set; }
        public DateTime? fechaMod { get; set; }
        public int? usuarioMod { get; set; }
        public bool active { get; set; }

    }
}
