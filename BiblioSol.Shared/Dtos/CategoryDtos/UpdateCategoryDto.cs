﻿namespace BiblioSol.Shared.Dtos.CategoryDtos
{
    public record UpdateCategoryDto
    {
        public int idCategoria { get; set; }
        public string descripcion { get; set; } = string.Empty;
        public DateTime? fechaModificacion { get; set; }
        public int? usuarioModificacionId { get; set; }
        public bool active { get; set; }
    }
}
