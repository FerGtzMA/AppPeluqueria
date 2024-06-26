﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppPeluqueriaMVC.Models
{
    public class Cita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoServicio { get; set; }
        public DateTime Created {  get; set; }
        [ForeignKey("Empleado")]
        public int Id_Empleado { get; set; }
        [ForeignKey("Cliente")]
        public int Id_Cliente { get; set; }

        public Empleado Empleado { get; set; }
        public Cliente Cliente { get; set; }
        public List<Cosmetico> Cosmeticos { get; set; } = new List<Cosmetico>();
        public List<Servicio> Servicios { get; set; } = new List<Servicio>();

        public double CostoTotal { get; set; }
        //public List<int> SelectedCosmeticoIds { get; set; } = new List<int>();
    }
}
