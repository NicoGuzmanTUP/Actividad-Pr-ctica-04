using GestionTurnosPeluqueria.Models;

namespace GestionTurnosPeluqueria.Data.Repositories
{
    public interface ITurnoRepository
    {
        Task<List<Turno>> GetAll();
        Task<Turno> GetById(int id);
        Task Update(Turno turno);
        Task Saved(Turno turno);
        Task Delete(int id);
        bool ValidateDate(DateTime fecha);
        Task<bool> ExistsTurno(DateTime fecha, string hora);
        Task<Turno> GetByClienteDate(string cliente, DateTime fecha);
    }
}
