using GestionTurnosPeluqueria.Data.Repositories;
using GestionTurnosPeluqueria.Data.Servicios;
using GestionTurnosPeluqueria.DTOs;
using GestionTurnosPeluqueria.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionTurnosPeluqueria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnosController : ControllerBase
    {
        private readonly ITurnoRepository _repository;
        private readonly ITurnoService _turnoService;

        public TurnosController(ITurnoRepository repository, ITurnoService turnoService)
        {
            _repository = repository;
            _turnoService = turnoService;   
        }

        // GET: api/<TurnosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repository.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error desconocido {ex}");
            }
        }

        [HttpGet("/clientes/{cliente}&{fecha}")]
        public async Task<IActionResult> GetByClienteDate(string cliente, DateTime fecha)
        {
            try
            {
                var result = await _turnoService.ValidarTurno(cliente, fecha);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error desconocido {ex}");
            }
        }

        // GET api/<TurnosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var turno = await _turnoService.GetById(id);
                if(turno == null)
                {
                    return NotFound("No encontrado");
                }
                return Ok(turno);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error desconocido {ex}");
            }
        }

        // POST api/<TurnosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TurnoDTO turnoDTO)
        {
            try
            {
                if (await _repository.ExistsTurno(turnoDTO.Fecha, turnoDTO.Hora))
                {
                    return BadRequest("Ya existe un turno registrado para esa fecha y hora.");
                }
                if (!_repository.ValidateDate(turnoDTO.Fecha))
                {
                    return BadRequest("La fecha de reserva debe estar entre el día siguiente y 45 días desde hoy.");
                }
                var turno = new Turno
                {
                    Fecha = turnoDTO.Fecha,
                    Hora = turnoDTO.Hora,
                    Cliente = turnoDTO.Cliente,
                };                 
                await _repository.Saved(turno);
                return Ok("Agregado éxitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error desconocido {ex.Message}");
            }
        }

        // PUT api/<TurnosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Turno turno)
        {
            if(id != turno.TurnoId)
            {
                return BadRequest("El id no coincide");
            }
            try
            {
                await _turnoService.Update(turno);
                return Ok("Actualizado correctamente");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error desconocido {ex.Message}");
            }
        }

        // DELETE api/<TurnosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var turno = await _turnoService.GetById(id);
                if(turno == null)
                {
                    return BadRequest("No encontrado");
                }
                await _turnoService.Delete(id);
                return Ok($"Turno eliminado correctamente {turno}");
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Error desconocido {ex.Message}");
            }
        }
    }
}
