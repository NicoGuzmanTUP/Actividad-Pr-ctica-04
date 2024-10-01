using System.ComponentModel.DataAnnotations;

namespace GestionTurnosPeluqueria.DTOs
{
    public class TurnoDTO
    {
        public DateTime Fecha { get; set; }
        public string? Hora { get; set; }

        public string? Cliente { get; set; }
    }
}
