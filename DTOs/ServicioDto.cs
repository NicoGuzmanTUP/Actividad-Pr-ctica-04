using System.ComponentModel.DataAnnotations;

namespace GestionTurnosPeluqueria.DTOs
{
    public class ServicioDto
    {
        [Required]
        public string ServicioName {  get; set; }
        [Required]
        public double Costo { get; set; }
        public bool EnPromocion {get;set;}


    }
}
