using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppPeluqueriaMVC.Models
{
    public class Cosmetico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }
        [Required(ErrorMessage = "El nombre del producto es necesario")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La cantidad del cosmetico es necesario")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "El precio del cosmetico es necesario")]
        public double Precio { get; set; }
        public DateTime Created { get; set; }

        public List<Cita> Citas { get; set; } = new List<Cita>();

        public byte[]? imagenProducto { get; set; }
        // Nuevo campo para almacenar la URL de la imagen
        public string? ImagenUrl { get; set; }
    }
}
