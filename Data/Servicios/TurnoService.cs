using GestionTurnosPeluqueria.Data.Repositories;
using GestionTurnosPeluqueria.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionTurnosPeluqueria.Data.Servicios
{
    public class TurnoService : ITurnoService
    {
        private readonly ITurnoRepository _turnoRepository;

        public TurnoService(ITurnoRepository repository)
        {
            _turnoRepository = repository;
        }

        public async Task Delete(int id)
        {
            await _turnoRepository.Delete(id);
        }

        public async Task<bool> ExistsTurno(DateTime fecha, string hora)
        {
            return await _turnoRepository.ExistsTurno(fecha, hora);
        }

        public async Task<List<Turno>> GetAll()
        {                
            return await _turnoRepository.GetAll();
        }

        public async Task<Turno> GetById(int id)
        {
            return await _turnoRepository.GetById(id);
        }

        public async Task<List<Turno>> GetTurnosCancelados(int dias)
        {
            throw new NotImplementedException();
        }

        public async Task Saved(Turno turno)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Turno turno)
        {
             await _turnoRepository.Update(turno);
        }

        public async Task<bool> ValidarTurno(string cliente, DateTime fecha)
        {           
            return await _turnoRepository.GetByClienteDate(cliente, fecha) != null;
        }

    }
}
