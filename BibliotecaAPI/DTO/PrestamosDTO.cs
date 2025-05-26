using BibliotecaAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.DTO
{
    public class PrestamosDTO
    {
        [Key]
        public int IdPrestamo { get; set; }
        public int IdLector { get; set; }
        [ForeignKey("IdLector")]
        public LectoresDTO Lectores { get; set; }
        public int IdBibliotecario { get; set; }
        [ForeignKey("IdBibliotecario")]
        public BibliotecariosDTO Bibliotecarios { get; set; }
        public int IdEjemplar { get; set; }

        [ForeignKey("IdEjemplar")]
        public EjemplaresModel Ejemplares { get; set; }

        public DateOnly FechaPrestamo { get; set; }
        public DateOnly FechaDevolucion { get; set; }
        public string? NombreLector { get; set; }
        public string? NombreBibliotecario { get; set; }
    }
}
