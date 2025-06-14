namespace BiblioSol.Application.DTOs.Library.Category
{
    public record CategoriaAddDto
    {

        //COLOCAR SOLO LOS CAMPOS NECESARIOS PARA CREAR LA CATEGORIA.
        public string descripcion { get; set; } = string.Empty;
        public DateTime fechaCreacion { get; set; }
        public int usuarioCreacionId { get; set; }
        public bool active { get; set; } = true;


    }
}
