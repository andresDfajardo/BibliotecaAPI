using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.Models
{
    public class TarifasModel
    {
        [Key]
        public int IdTarifa { get; set; }
        public int IdPrestamo { get; set; }
        public int DiasRetraso { get; set; }
        public int MontoTarifa { get; set; }
    }
}
