using BibliotecaAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.DTO
{
    public class LectoresDTO
    {
        [Key]
        public int IdLector { get; set; }
        public int? IdPersona { get; set; }
        [ForeignKey("IdPersona")]
        public PersonasModel Personas { get; set; }
        public DateOnly? FechaRegistro { get; set; }
        public string Ocupacion { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? DocumentoIdentidad { get; set; }
    }
}
