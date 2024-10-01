using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionTurnosPeluqueria.Models
{
    //[Table("T_Servicios")]
    public class Servicio
    {
        [Key]
        public int Id { get; set; }

        public string ServicioName { get; set; }
        [Required]
        public double Costo { get; set; }
        [Required]
        public bool EnPromocion { get; set; }

        // Relación 1:1 con DetalleTurno
        public DetalleTurno? DetalleTurno { get; set; }
        //public int DetalleId { get; set; }
    }
}
