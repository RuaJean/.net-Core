using PruebaTecnica_Backend.Models;
using PruebaTecnica_Backend.Repositories;

namespace PruebaTecnica_Backend.Services
{
    public class EntidadService : IEntidadService
    {
        private readonly IEntidadRepository _repository;

        public EntidadService(IEntidadRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Entidad> GetAll() => _repository.GetAll();

        public Entidad GetById(int id) => _repository.GetById(id);

        public void Create(Entidad entidad)
        {
            _repository.Create(entidad);
            _repository.Save();
        }

        public void Update(Entidad entidad)
        {
            _repository.Update(entidad);
            _repository.Save();
        }

        public void Delete(int id)
        {
            var entidad = _repository.GetById(id);
            if (entidad != null)
            {
                _repository.Delete(entidad);
                _repository.Save();
            }
        }
    }
}
