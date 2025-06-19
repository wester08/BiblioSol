

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BiblioSol.Domain.Base;

namespace BiblioSol.Domain.Entities
{
    [Table("PlantillaNotificaciones", Schema = "Biblioteca")]
    public class PlantillaNotificaciones : AuditEntity
    {
        [Key]
        public int idPlantilla { get; set; }
        public int tipoNotificacionId { get; set; }
        public string asunto { get; set; }
        public string cuerpo { get; set; } = string.Empty;


    }
}
