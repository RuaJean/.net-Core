using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica_Backend.Data;
using PruebaTecnica_Backend.Models;

namespace PruebaTecnica_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntidadesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EntidadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Entidades.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var entidad = _context.Entidades.Find(id);
            if (entidad == null) return NotFound();
            return Ok(entidad);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Create(Entidad entidad)
        {
            _context.Entidades.Add(entidad);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = entidad.Id }, entidad);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, Entidad entidad)
        {
            var existing = _context.Entidades.Find(id);
            if (existing == null) return NotFound();
            existing.Nombre = entidad.Nombre;
            existing.Descripcion = entidad.Descripcion;
            _context.SaveChanges();
            return NoContent();
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entidad = _context.Entidades.Find(id);
            if (entidad == null) return NotFound();
            _context.Entidades.Remove(entidad);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
