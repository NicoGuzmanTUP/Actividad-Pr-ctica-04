using GestionTurnosPeluqueria.Models;

namespace GestionTurnosPeluqueria.Data.Repositories
{
    public interface IDetalleTurnoRepository
    {
        List<DetalleTurno> GetAll();
        DetalleTurno GetById(int id);
        void Saved(DetalleTurno detalleTurno);
        void Update(DetalleTurno detalleTurno);
        void Delete(int id);

    }
}
