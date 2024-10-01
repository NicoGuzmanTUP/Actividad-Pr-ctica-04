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
            var turno = await GetById(id);
            _context.turnos.Remove(turno);
            await _context.SaveChangesAsync();
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
            var turnoExiste = await _context.turnos
                .Include(t => t.DetallesTurno)
                .FirstOrDefaultAsync(t => t.TurnoId == t.TurnoId);
            if(turnoExiste == null)
            {
                throw new KeyNotFoundException($"El turno con ID {turno.TurnoId} no existe.");
            }
            turnoExiste.Fecha = turno.Fecha;
            turnoExiste.Hora = turno.Hora;
            turnoExiste.Cliente = turno.Cliente;

            await _context.SaveChangesAsync();
        }
        public async Task<Turno?> GetByClienteDate(string cliente, DateTime fecha)
        {            
            return await _context.turnos.FirstOrDefaultAsync(x => x.Cliente.ToLower() == cliente.ToLower() && x.Fecha == fecha);

        }

        public bool ValidateDate(DateTime fecha)
        {
            var hoy = DateTime.Now;
            var minFecha = hoy.AddDays(1);
            var maxFecha = hoy.AddDays(45);

            if(fecha < minFecha || fecha > maxFecha)
            {
               // throw new ArgumentException("La fecha de reserva debe estar entre el día siguiente y 45 días desde hoy.");
               return false;
            }
            return true;

        }

        public async Task<bool> ExistsTurno(DateTime fecha, string hora)
        {
            return await _context.turnos.AnyAsync(t => t.Fecha == fecha && t.Hora == hora);
        }
    }
}
