using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaAPI.Models
{
    public class EjemplaresModel
    {
        [Key]
        public int IdEjemplar { get; set; }
        public int? IdLibro { get; set; }
        [ForeignKey("IdLibro")]
        public LibrosModel Libros { get; set; }
        public string Ubicacion { get; set; }
    }
}
