using GestionTurnosPeluqueria.Data.Repositories;
using GestionTurnosPeluqueria.DTOs;
using GestionTurnosPeluqueria.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionTurnosPeluqueria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private IServicioRepository _repository;

        public ServiciosController(IServicioRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<ServiciosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var servicios = await _repository.GetAll();
                return Ok(servicios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error desconocido {ex}");
            }
        }

        // GET api/<ServiciosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            try
            {
                var servicio =await _repository.GetById(id);
                if (servicio == null)
                {
                    return NotFound();
                }
                return Ok(servicio);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error desconocido {ex.Message}");
            }
        }

        // POST api/<ServiciosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ServicioDto servicioDto)//puedo modificarlo en el dto
        {
            try
            {
                var servicio = new Servicio
                {
                    ServicioName = servicioDto.ServicioName,
                    Costo = servicioDto.Costo,
                    EnPromocion = servicioDto.EnPromocion
                    // Otros campos según la estructura de tu DTO
                };
                 await _repository.Saved(servicio);
                return Ok("Agregado exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error desconocido {ex.Message}");
            }
        }

        // PUT api/<ServiciosController>/5
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] Servicio servicio)
        //{
        //    try
        //    {
        //        if(servicio == null)
        //        {
        //            return BadRequest("Faltan completan algunos campos");
        //        }
        //        var oServicio = _repository.GetById(id);
        //        if(oServicio == null)
        //        {
        //            return BadRequest("Servicio no encontrado");
        //        }
        //        oServicio.ServicioName = servicio.ServicioName;
        //        oServicio.EnPromocion = servicio.EnPromocion;
        //        oServicio.Costo = servicio.Costo;

        //        _repository.Saved(oServicio);
        //        return Ok($"Actualizado correctamente: {oServicio}");
        //    }
        //    catch(Exception ex)
        //    {
        //        return StatusCode(500, $"Error desconocido {ex.Message}");
        //    }
        //}

        // DELETE api/<ServiciosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var oServicio = _repository.GetById(id);
                if(oServicio == null)
                {
                    return BadRequest("Servicio no encontrado");
                }
                _repository.Delete(id);
                return Ok($"Servicio eliminado correctamente {oServicio.Result}");
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Error desconocido {ex.Message}");
            }
        }
    }
}
