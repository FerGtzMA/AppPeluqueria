using AppPeluqueriaMVC.Data;
using AppPeluqueriaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AppPeluqueriaMVC.Controllers
{
    public class ServicioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServicioController(ApplicationDbContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<IActionResult> VistaServicio()
        {
            return View(await _context.Servicio.ToListAsync());
        }

        //[HttpGet]
        //public IActionResult GetImage(int codigo)
        //{
        //    var cosmetico = _context.Cosmetico.FirstOrDefault(a => a.Codigo == codigo);
        //    if (cosmetico != null && cosmetico.imagenProducto != null)
        //    {
        //        return File(cosmetico.imagenProducto, "image/jpeg"); // Asegúrate de ajustar el tipo MIME según el formato de la imagen
        //    }
        //    return NotFound();
        //}

        [HttpGet]
        public IActionResult CrearServicio()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearServicio(Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                servicio.Created = DateTime.Now;
                _context.Servicio.Add(servicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(VistaServicio));
            }

            return View(servicio);
        }

        [HttpGet]
        public IActionResult EditarServicio(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicio = _context.Servicio.Find(id);
            if (servicio == null)
            {
                return NotFound();
            }

            return View(servicio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarServicio(Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                _context.Update(servicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(VistaServicio));
            }

            return View(servicio);
        }

        [HttpGet]
        public IActionResult DetalleServicio(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicio = _context.Servicio.Find(id);
            if (servicio == null)
            {
                return NotFound();
            }

            return View(servicio);
        }

        [HttpPost, ActionName("BorrarServicio")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarServicio(int? id)
        {
            var servicio = await _context.Servicio.FindAsync(id);
            if (servicio == null)
            {
                return View();
            }

            _context.Servicio.Remove(servicio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(VistaServicio));
        }
    }
}
