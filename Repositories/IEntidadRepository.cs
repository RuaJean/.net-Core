using PruebaTecnica_Backend.Models;

namespace PruebaTecnica_Backend.Repositories
{
    public interface IEntidadRepository
    {
        IEnumerable<Entidad> GetAll();
        Entidad GetById(int id);
        void Create(Entidad entidad);
        void Update(Entidad entidad);
        void Delete(Entidad entidad);
        void Save();
    }
}
