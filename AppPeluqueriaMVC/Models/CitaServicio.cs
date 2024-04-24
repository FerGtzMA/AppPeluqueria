namespace AppPeluqueriaMVC.Models
{
    public class CitaServicio
    {
        public int CitaId { get; set; }
        public Cita Cita { get; set; }
        public int ServicioId { get; set; }
        public Servicio Servicio { get; set; }
    }
}
