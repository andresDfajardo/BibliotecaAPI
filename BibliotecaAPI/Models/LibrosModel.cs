using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace BibliotecaAPI.Models
{
    public class LibrosModel
    {
        [Key]
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public int? AnioPublicacion { get; set; }
        public int IdEditorial { get; set; }
    }
}
