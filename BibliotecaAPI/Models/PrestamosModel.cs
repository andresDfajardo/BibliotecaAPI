using BibliotecaAPI.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaAPI.Models
{
    public class PrestamosModel
    {
        [Key]
        public int IdPrestamo { get; set; }
        public int IdLector { get; set; }
        [ForeignKey("IdLector")]
        public LectoresModel Lectores { get; set; }
        public int IdBibliotecario { get; set; }
        [ForeignKey("IdBibliotecario")]
        public BibliotecariosModel Bibliotecarios { get; set; }
        public int IdEjemplar { get; set; }

        [ForeignKey("IdEjemplar")]
        public EjemplaresModel Ejemplares { get; set; }
        public DateOnly FechaPrestamo { get; set; }
        public DateOnly FechaDevolucion { get; set; }
    }
}
