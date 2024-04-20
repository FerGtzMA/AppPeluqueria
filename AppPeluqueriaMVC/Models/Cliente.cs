using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppPeluqueriaMVC.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string DNI { get; set; }
        [Required(ErrorMessage = "El nombre del cliente es necesario")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido del cliente es necesario")]
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Calle { get; set; }
        public string NumInt { get; set; }
        public string Colonia { get; set; }
        public string CodigoPostal { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string Tratamientos { get; set; }
        public DateTime Created { get; set; }

        public List<Cita> Citas { get; set; } = new List<Cita>();
    }
}
