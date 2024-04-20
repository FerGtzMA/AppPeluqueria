using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppPeluqueriaMVC.Models
{
    public class Empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "El DNI del empleado es necesario")]
        public string DNI { get; set; }
        [Required(ErrorMessage = "El nombre del empleado es necesario")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido del empleado es necesario")]
        public string Apellido { get; set; }
        public string Especialidad { get; set; }
        public double Sueldo { get; set; }
        public DateTime Created { get; set; }

        public List<Cita> Citas { get; set; } = new List<Cita>();
    }
}
