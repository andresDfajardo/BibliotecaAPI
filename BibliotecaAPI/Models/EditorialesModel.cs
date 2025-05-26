using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.Models
{
    public class EditorialesModel
    {
        [Key]
        public int IdEditorial { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string SitioWeb { get; set; }
    }
}
