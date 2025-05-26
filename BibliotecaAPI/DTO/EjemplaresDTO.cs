using BibliotecaAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.DTO
{
    public class EjemplaresDTO
    {
        [Key]
        public int IdEjemplar { get; set; }
        public int? IdLibro { get; set; }
        [ForeignKey("IdLibro")]
        public LibrosModel Libros { get; set; }
        public string Ubicacion { get; set; }
        public string? Titulo { get; set; }
    }
}
