using BibliotecaAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.DTO
{
    public class BibliotecariosDTO
    {
        [Key]
        public int IdBibliotecario { get; set; }
        public int? IdPersona { get; set; }
        [ForeignKey("IdPersona")]
        public PersonasModel Personas { get; set; }
        public DateOnly? FechaContratacion { get; set; }
        public string Turno { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? DocumentoIdentidad { get; set; }
    }
}
