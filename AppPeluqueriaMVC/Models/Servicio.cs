using System.ComponentModel.DataAnnotations;

namespace AppPeluqueriaMVC.Models
{
    public class Servicio
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public double? Precio { get; set; }
        public DateTime Created { get; set; }

        public List<Cita> Citas { get; set; } = new List<Cita>();
    }
}
