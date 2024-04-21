using AppPeluqueriaMVC.Data;
using AppPeluqueriaMVC.Models;
using AppPeluqueriaMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AppPeluqueriaMVC.Controllers
{
    public class CitaController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CitaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> VistaCita()
        {
            var citas = _context.Cita
                .Include(c => c.Empleado) // Asegúrate de incluir el empleado
                .Include(c => c.Cliente)
                .ToList();

            return View(citas);
        }


        public IActionResult CrearCita()
        {
            // Cargar la lista de empleados y almacenarla en ViewBag
            ViewBag.Empleados = _context.Empleado.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Nombre  // Suponiendo que quieres mostrar el nombre
            }).ToList();

            ViewBag.Clientes = _context.Cliente.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Nombre  // Suponiendo que quieres mostrar el nombre
            }).ToList();

            return View(new Cita());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearCita(Cita cita)
        {
            _context.Cita.Add(cita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(VistaCita));
        }

        [HttpGet]
        public IActionResult EditarCita(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = _context.Cita.Find(id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarCita(Cita cita)
        {
            _context.Update(cita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(VistaCita));
        }

        [HttpGet]
        public IActionResult DetalleCita(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = _context.Cita.Find(id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        [HttpPost, ActionName("BorrarCita")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarCita(int? id)
        {
            var cita = await _context.Cita.FindAsync(id);
            if (cita == null)
            {
                return View();
            }

            _context.Cita.Remove(cita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(VistaCita));
        }


    }
}
