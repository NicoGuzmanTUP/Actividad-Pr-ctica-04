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

        //[HttpGet("/clientes/{cliente}&{fecha}")]
        //public async Task<IActionResult> GetByClienteDate(string cliente, DateTime fecha)
        //{
        //    try
        //    {
        //        var result = await _turnoService.ValidarTurno(cliente, fecha);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Error desconocido {ex}");
        //    }
        //}

        // GET api/<TurnosController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<TurnosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TurnoDTO turnoDTO)
        {
            try
            {
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
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<TurnosController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
