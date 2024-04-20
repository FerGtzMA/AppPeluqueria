using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppPeluqueriaMVC.Models
{
    public class Cita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Id_Empleado { get; set; }
        public int Id_Cliente { get; set; }
        public string TipoServicio { get; set; }
        public DateTime Created {  get; set; }

        public Empleado Empleado { get; set; }
        public Cliente Cliente { get; set; }
        public List<Cosmetico> Cosmeticos { get; set; } = new List<Cosmetico>();
    }
}
