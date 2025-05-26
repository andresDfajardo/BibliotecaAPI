using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaAPI.Models
{
    public class BibliotecariosModel
    {
        [Key]
        public int IdBibliotecario { get; set; }
        public int? IdPersona { get; set; }
        [ForeignKey("IdPersona")]
        public PersonasModel Personas { get; set; }
        public DateOnly? FechaContratacion { get; set; }
        public string Turno { get; set; }
    }
}
