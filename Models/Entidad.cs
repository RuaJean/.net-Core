namespace PruebaTecnica_Backend.Models
{
    public class Entidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

    }
}
