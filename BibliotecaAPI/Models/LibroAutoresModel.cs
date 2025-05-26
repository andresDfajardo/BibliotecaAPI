using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.Models
{
    public class LibroAutoresModel
    {
        [Key]
        public int IdLibro { get; set; }
        public int IdAutor { get; set; }
        public string? rol { get; set; }
    }
}
