using GestionTurnosPeluqueria.Data.Repositories;
using GestionTurnosPeluqueria.DTOs;
using GestionTurnosPeluqueria.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionTurnosPeluqueria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesController : ControllerBase
    {
        private IDetalleTurnoRepository _repository;

        public DetallesController(IDetalleTurnoRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<DetallesController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAll());
            }
            catch (Exception ex) 
            {
                return StatusCode(500, $"Error desconocido {ex}");
            }
        }

        // GET api/<DetallesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<DetallesController>
        [HttpPost]
        public IActionResult Post([FromBody] DetallesDTO detalleDTO)
        {
            try
            {
                var detalle = new DetalleTurno
                {
                    ServicioId = detalleDTO.ServicioId,
                    Observaciones = detalleDTO.Observaciones,
                    TurnoId = detalleDTO.TurnoId
                };
                _repository.Saved(detalle);
                return Ok($"Guardado correctamente {detalle}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error desconocido {ex}");
            }
        }

        // PUT api/<DetallesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<DetallesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var oDetalle = _repository.GetById(id);
                if(oDetalle == null)
                {
                    return BadRequest("Detalle no encontrado");
                }
                _repository.Delete(id);
                return Ok("Eliminado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error desconocido {ex}");
            }
        }
    }
}
