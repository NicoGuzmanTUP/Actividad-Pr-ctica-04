using GestionTurnosPeluqueria.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionTurnosPeluqueria.DTOs
{
    public class DetallesDTO
    {
        public int ServicioId { get; set; }
        public string? Observaciones { get; set; }

        public int TurnoId { get; set; }
    }
}
