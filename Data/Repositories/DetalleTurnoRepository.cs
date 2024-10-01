using GestionTurnosPeluqueria.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionTurnosPeluqueria.Data.Repositories
{
    public class DetalleTurnoRepository : IDetalleTurnoRepository
    {
        private readonly ServicioDbContext _context;

        public DetalleTurnoRepository(ServicioDbContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            var detalle = GetById(id);
            if (detalle != null) 
            { 
                _context.Remove(detalle);
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("No sé");
            }
        }

        public List<DetalleTurno> GetAll()
        {
            return _context.detalles.ToList();
        }

        public DetalleTurno GetById(int id)
        {
            return _context.detalles.FirstOrDefault(s => s.DetalleTurnoId == id);
        }

        public void Saved(DetalleTurno detalleTurno)
        {
            if (detalleTurno.DetalleTurnoId == 0)
            {
                _context.detalles.Add(detalleTurno);
            }
            else
            {
                _context.detalles.Update(detalleTurno);
            }
            _context.SaveChanges();
        }

        public void Update(DetalleTurno detalleTurno)
        {
            throw new NotImplementedException();
        }
    }
}
