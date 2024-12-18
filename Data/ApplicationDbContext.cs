using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica_Backend.Models;

namespace PruebaTecnica_Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Entidad> Entidades { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
