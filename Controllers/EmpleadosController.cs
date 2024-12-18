using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica_Backend.Data;
using PruebaTecnica_Backend.Models;
using System.Data;


[ApiController]
[Route("api/[controller]")]
public class EmpleadosController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public EmpleadosController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_context.Empleados.ToList());

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var empleado = _context.Empleados.Find(id);
        return empleado == null ? NotFound() : Ok(empleado);
    }

    [Authorize(Roles = "Administrador")]
    [HttpPost]
    public IActionResult Create(Empleado empleado)
    {
        _context.Empleados.Add(empleado);
        _context.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = empleado.Id }, empleado);
    }

    [Authorize(Roles = "Administrador")]
    [HttpPut("{id}")]
    public IActionResult Update(int id, Empleado empleado)
    {
        var existing = _context.Empleados.Find(id);
        if (existing == null) return NotFound();

        existing.Nombre = empleado.Nombre;
        existing.Cargo = empleado.Cargo;
        existing.EntidadId = empleado.EntidadId;

        _context.SaveChanges();
        return NoContent();
    }

    [Authorize(Roles = "Administrador")]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var empleado = _context.Empleados.Find(id);
        if (empleado == null) return NotFound();

        _context.Empleados.Remove(empleado);
        _context.SaveChanges();
        return NoContent();
    }
}
