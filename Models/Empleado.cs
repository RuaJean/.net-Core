using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnica_Backend.Models
{
    public class Empleado
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Cargo { get; set; }

        [Required]
        public int EntidadId { get; set; } // Clave foránea

        [ForeignKey("EntidadId")]
        public Entidad? Entidad { get; set; } 
    }
}
