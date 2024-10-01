using GestionTurnosPeluqueria.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionTurnosPeluqueria.Data.Repositories
{
    public class ServicioRepository : IServicioRepository
    {
        private readonly ServicioDbContext _context;

        public ServicioRepository(ServicioDbContext context)
        {
            _context = context;
        }

        public async Task<List<Servicio>> GetAll()
        {
            return await _context.servicios.ToListAsync();
        }

        public async Task<Servicio> GetById(int id)
        {               
            return await _context.servicios.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task Saved(Servicio servicio)
        {
            if (servicio.Id == 0)
            {
                _context.servicios.Add(servicio);
            }
            else
            {
                _context.servicios.Update(servicio);
            }
            await _context.SaveChangesAsync();
        }

        public async Task Update(Servicio servicio)
        {
            
        }        

        public async Task Delete(int id)
        {
            var servicio = await GetById(id);
            _context.servicios.Remove(servicio);
            await _context.SaveChangesAsync();
        }
        
    }
}
