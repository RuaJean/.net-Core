namespace PruebaTecnica_Backend.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Rol { get; set; } = "Usuario"; // Valor predeterminado
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
