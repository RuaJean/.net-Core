using PruebaTecnica_Backend.Models;

namespace PruebaTecnica_Backend.Services
{
    public interface IEntidadService
    {
        IEnumerable<Entidad> GetAll();
        Entidad GetById(int id);
        void Create(Entidad entidad);
        void Update(Entidad entidad);
        void Delete(int id);
    }
}
