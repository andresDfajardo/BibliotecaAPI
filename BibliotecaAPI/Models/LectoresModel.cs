using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaAPI.Models
{
    public class LectoresModel
    {
        [Key]
        public int IdLector { get; set; }
        public int? IdPersona { get; set; }
        [ForeignKey("IdPersona")]
        public PersonasModel Personas { get; set; }
        public DateOnly? FechaRegistro { get; set; }
        public string Ocupacion { get; set; }
    }
}
