using AppPeluqueriaMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppPeluqueriaMVC.ViewModels
{
    public class CitaViewModel
    {
        public Cita Cita { get; set; }
        public IEnumerable<SelectListItem> Empleados { get; set; }
        public IEnumerable<SelectListItem> Clientes { get; set; }
    }
}
