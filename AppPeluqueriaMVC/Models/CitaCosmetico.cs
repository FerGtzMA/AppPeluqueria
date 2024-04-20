namespace AppPeluqueriaMVC.Models
{
    public class CitaCosmetico
    {
        public int CitaId { get; set; }
        public Cita Cita { get; set; }
        public int CosmeticoId { get; set; }
        public Cosmetico Cosmetico { get; set; }
    }
}
