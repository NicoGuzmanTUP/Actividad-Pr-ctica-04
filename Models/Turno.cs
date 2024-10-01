using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionTurnosPeluqueria.Models
{
    //[Table("T_Turnos")]
    public class Turno
    {
        [Key]
        public int TurnoId { get; set; }
        
        [Required]
        public DateTime Fecha { get; set; }
        public string? Hora { get; set; }
        
        [Required]
        public string? Cliente { get; set; }

        // Relación 1:N con DetalleTurno
        public ICollection<DetalleTurno>? DetallesTurno { get; set; }  // Un Turno puede tener varios DetallesTurno

    }
}
