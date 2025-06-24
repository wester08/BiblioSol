

namespace BiblioSol.Shared.Dtos
{
    public record AddCategoryDto
    {
        public string descripcion { get; set; } = string.Empty;
        public DateTime fechaCreacion { get; set; }
        public int usuarioCreacionId { get; set; }
        public bool active { get; set; }
    }
}
