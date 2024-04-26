using AppPeluqueriaMVC.Data;
using AppPeluqueriaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AppPeluqueriaMVC.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpleadoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> VistaEmpleados()
        {
            return View(await _context.Empleado.ToListAsync());
        }

        [HttpGet]
        public IActionResult CrearEmpleado()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearEmpleado(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                empleado.Created = DateTime.Now;
                _context.Empleado.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(VistaEmpleados));
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditarEmpleado(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = _context.Empleado.Find(id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarEmpleado(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Update(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(VistaEmpleados));
            }
            return View();
        }

        [HttpGet]
        public IActionResult DetalleEmpleado(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = _context.Empleado.Find(id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        [HttpPost, ActionName("BorrarEmpleado")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarEmpleado(int? id)
        {
            var empleado = await _context.Empleado.FindAsync(id);
            if (empleado == null)
            {
                return View();   
            }

            _context.Empleado.Remove(empleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(VistaEmpleados));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
