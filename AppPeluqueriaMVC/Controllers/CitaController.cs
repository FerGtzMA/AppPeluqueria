using AppPeluqueriaMVC.Data;
using AppPeluqueriaMVC.Models;
using AppPeluqueriaMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
                .Include(c => c.Empleado)
                .Include(c => c.Cliente)
                .Include(c => c.Cosmeticos)
                .ToList();

            return View(citas);
        }

        public IActionResult GetImage(int codigo)
        {
            var cosmetico = _context.Cosmetico.FirstOrDefault(a => a.Codigo == codigo);
            if (cosmetico != null && cosmetico.imagenProducto != null)
            {
                return File(cosmetico.imagenProducto, "image/jpeg");
            }
            return NotFound();
        }

        private void CargarInformacion()
        {
            // Cargar la lista de empleados y almacenarla en ViewBag
            ViewBag.Empleados = _context.Empleado.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Nombre + e.Apellido
            }).ToList();

            ViewBag.Clientes = _context.Cliente.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Nombre + e.Apellido
            }).ToList();

            ViewBag.Servicios = _context.Servicio.Select(e => new SelectListItem
            {
                Value = e.Nombre.ToString(),
                Text = e.Nombre
            }).ToList();

            ViewBag.Cosmeticos = new SelectList(_context.Cosmetico, "Codigo", "Nombre");
        }

        public IActionResult CrearCita()
        {
            CargarInformacion();
            return View(new Cita());

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearCita(Cita cita, [FromForm] List<int> cosmeticoIds)
        {
            cita.Created = DateTime.Now;
            _context.Cita.Add(cita);
            await _context.SaveChangesAsync();

            // Asociar cosméticos seleccionados
            foreach (var cosmeticoId in cosmeticoIds)
            {
                var citaCosmetico = new CitaCosmetico
                {
                    CitaId = cita.Id,
                    CosmeticoId = cosmeticoId
                };
                _context.CitaCosmetico.Add(citaCosmetico);
            }
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

            var cita = _context.Cita
                .Include(c => c.Cosmeticos)
                .FirstOrDefault(c => c.Id == id);

            if (cita == null)
            {
                return NotFound();
            }
            CargarInformacion();
            return View(cita);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarCita(int id, Cita cita, [FromForm] List<int> cosmeticoIds)
        {
            if (id != cita.Id)
            {
                return NotFound();
            }
            try
            {
                _context.Update(cita);
                await _context.SaveChangesAsync();

                // Eliminar todos los cosméticos actuales
                var currentCosmeticos = _context.CitaCosmetico.Where(cc => cc.CitaId == cita.Id);
                _context.CitaCosmetico.RemoveRange(currentCosmeticos);

                // Agregar los nuevos cosméticos seleccionados
                foreach (var cosmeticoId in cosmeticoIds)
                {
                    var citaCosmetico = new CitaCosmetico
                    {
                        CitaId = cita.Id,
                        CosmeticoId = cosmeticoId
                    };
                    _context.CitaCosmetico.Add(citaCosmetico);
                }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitaExists(cita.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            CargarInformacion();
            return RedirectToAction(nameof(VistaCita));
        }

        private bool CitaExists(int id)
        {
            return _context.Cita.Any(e => e.Id == id);
        }

        [HttpGet]
        public async Task<IActionResult> DetalleCita(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Usando Include para cargar las relaciones
            var cita = await _context.Cita
                .Include(c => c.Empleado)
                .Include(c => c.Cliente)
                .Include(c => c.Cosmeticos)
                .FirstOrDefaultAsync(c => c.Id == id);

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
