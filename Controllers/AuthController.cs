using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica_Backend.Data;
using PruebaTecnica_Backend.Helpers;
using PruebaTecnica_Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace PruebaTecnica_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly string _jwtKey;

        public AuthController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _jwtKey = configuration["Jwt:Key"]; // Clave secreta JWT
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Usuario user)
        {
            // Verificar si el nombre de usuario ya existe
            if (await _context.Usuarios.AnyAsync(u => u.NombreUsuario == user.NombreUsuario))
                return BadRequest("El nombre de usuario ya existe");

            // Asignar rol por defecto: Usuario
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            user.Rol = "Usuario";

            _context.Usuarios.Add(user);
            await _context.SaveChangesAsync();

            // Generar token JWT para el nuevo usuario registrado
            var token = JwtHelper.GenerateToken(user.NombreUsuario, user.Rol, _jwtKey);

            return Ok(new
            {
                Message = "Usuario registrado correctamente",
                Token = token
            });
        }

        [HttpPost("register/admin")]
        [Authorize(Roles = "Administrador")] // Solo accesible por administradores
        public async Task<IActionResult> RegisterAdmin([FromBody] Usuario user)
        {
            // Verificar si el nombre de usuario ya existe
            if (await _context.Usuarios.AnyAsync(u => u.NombreUsuario == user.NombreUsuario))
                return BadRequest("El nombre de usuario ya existe");

            // Asignar rol: Administrador
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            user.Rol = "Administrador";

            _context.Usuarios.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = "Administrador registrado correctamente"
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Usuario user)
        {
            var dbUser = await _context.Usuarios.FirstOrDefaultAsync(u => u.NombreUsuario == user.NombreUsuario);
            if (dbUser == null || !BCrypt.Net.BCrypt.Verify(user.PasswordHash, dbUser.PasswordHash))
                return Unauthorized("Credenciales incorrectas");

            // Generar token JWT
            var token = JwtHelper.GenerateToken(dbUser.NombreUsuario, dbUser.Rol, _jwtKey);

            return Ok(new
            {
                Token = token,
            });
        }
    }
}
