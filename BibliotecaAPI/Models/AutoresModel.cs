using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.Models
{
    public class AutoresModel
    {
        [Key]
        public int IdAutor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateOnly? FechaNacimiento { get; set; }
        public string Nacionalidad { get; set; }
    }
}
