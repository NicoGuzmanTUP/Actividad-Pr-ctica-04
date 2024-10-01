using GestionTurnosPeluqueria.Models;

namespace GestionTurnosPeluqueria.Data.Servicios
{
    public interface ITurnoService
    {
        Task<List<Turno>> GetAll();
        Task<Turno> GetById(int id);
        Task Update(Turno turno);
        Task Saved(Turno turno);
        Task Delete(int id);

        Task<List<Turno>> GetTurnosCancelados(int dias);
        Task<bool> ValidarTurno(string cliente, DateTime fecha);
    }
}
