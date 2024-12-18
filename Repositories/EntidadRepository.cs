using PruebaTecnica_Backend.Data;
using PruebaTecnica_Backend.Models;

namespace PruebaTecnica_Backend.Repositories
{
    public class EntidadRepository : IEntidadRepository
    {
        private readonly ApplicationDbContext _context;

        public EntidadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Entidad> GetAll() => _context.Entidades.ToList();

        public Entidad GetById(int id) => _context.Entidades.Find(id);

        public void Create(Entidad entidad)
        {
            _context.Entidades.Add(entidad);
        }

        public void Update(Entidad entidad)
        {
            _context.Entidades.Update(entidad);
        }

        public void Delete(Entidad entidad)
        {
            _context.Entidades.Remove(entidad);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
