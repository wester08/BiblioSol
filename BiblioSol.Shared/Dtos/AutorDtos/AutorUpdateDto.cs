

namespace BiblioSol.Shared.Dtos.AutorDtos
{
    public record AutorUpdateDto
    {

        public int idAutor { get; set; }

        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime? fechaMod { get; set; }
        public int? usuarioMod { get; set; }

        public bool active { get; set; }


    }
}
