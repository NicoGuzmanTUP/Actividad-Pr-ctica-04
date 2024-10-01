using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionTurnosPeluqueria.Models
{
    //[Table("T_Detalles_Turnos")]
    public class DetalleTurno
    {
        [Key]
        public int DetalleTurnoId { get; set; }

        [ForeignKey("Servicio")]  // Especifica la clave foránea hacia Servicio
        public int ServicioId { get; set; }
        public string? Observaciones { get; set; }
        
        public Servicio? Servicio { get; set; }  // Un DetalleTurno tiene un Servicio

        [ForeignKey("Turno")]
        public int TurnoId { get; set; }  // Clave foránea para la relación con Turno
        public Turno? Turno { get; set; }  // Cada DetalleTurno pertenece a un Turno
    }
}
