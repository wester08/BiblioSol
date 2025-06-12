namespace BiblioSol.Application.DTOs.Library.Category
{
    public record CategoriaAddDto
    {

        //COLOCAR SOLO LOS CAMPOS NECESARIOS PARA CREAR LA CATEGORIA.
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; } = string.Empty;


    }
}
