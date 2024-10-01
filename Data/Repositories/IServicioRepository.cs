using GestionTurnosPeluqueria.Models;

namespace GestionTurnosPeluqueria.Data.Repositories
{
    public interface IServicioRepository
    {
        Task<List<Servicio>> GetAll();
        Task<Servicio> GetById(int id);
        Task Saved(Servicio servicio);
        Task Update(Servicio servicio);
        Task Delete(int id);
    }
}
