using GestionTurnosPeluqueria.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionTurnosPeluqueria.Data.Repositories
{
    public class TurnoRepository : ITurnoRepository
    {
        private readonly ServicioDbContext _context;

        public TurnoRepository(ServicioDbContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Turno>> GetAll()
        {
            return _context.turnos.ToList();
        }

        public async Task<Turno> GetById(int id)
        {
            return _context.turnos.FirstOrDefault(s => s.TurnoId == id);
        }
        
        public async Task Saved(Turno turno)
        {
            if(turno.TurnoId == 0)
            {
                _context.turnos.Add(turno);
            }
            else
            {
                _context.turnos.Update(turno);
            }
            _context.SaveChanges();
        }

        public async Task Update(Turno turno)
        {
            throw new NotImplementedException();
        }
        public async Task<Turno> GetByClienteDate(string cliente, DateTime fecha)
        {
            return await _context.turnos.FirstOrDefaultAsync(x => x.Cliente.Equals(cliente, StringComparison.CurrentCultureIgnoreCase) && x.Fecha.Equals(fecha));
        }
    }
}
