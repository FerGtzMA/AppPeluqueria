using AppPeluqueriaMVC.Data;
using AppPeluqueriaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web;
using System.IO;
using Microsoft.EntityFrameworkCore.Storage;

namespace AppPeluqueriaMVC.Controllers
{
    public class CosmeticoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CosmeticoController(ApplicationDbContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<IActionResult> VistaCosmetico()
        {
            return View(await _context.Cosmetico.ToListAsync());
        }

        [HttpGet]
        public IActionResult GetImage(int codigo)
        {
            var cosmetico = _context.Cosmetico.FirstOrDefault(a => a.Codigo == codigo);
            if (cosmetico != null && cosmetico.imagenProducto != null)
            {
                return File(cosmetico.imagenProducto, "image/jpeg"); // Asegúrate de ajustar el tipo MIME según el formato de la imagen
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult CrearCosmetico()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearCosmetico(Cosmetico cosmetico, IFormFile? upload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (upload != null && upload.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await upload.CopyToAsync(memoryStream);
                            cosmetico.imagenProducto = memoryStream.ToArray();
                        }
                    }
                    else
                    {
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Internal", "ProductEmpty.jpg");
                        cosmetico.imagenProducto = System.IO.File.ReadAllBytes(path);
                    }

                    _context.Cosmetico.Add(cosmetico);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(VistaCosmetico));
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                // Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(cosmetico);
        }

        [HttpGet]
        public IActionResult EditarCosmetico(int? codigo)
        {
            if (codigo == null)
            {
                return NotFound();
            }

            var cosmetico = _context.Cosmetico.Find(codigo);
            if (cosmetico == null)
            {
                return NotFound();
            }

            return View(cosmetico);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarCosmetico(Cosmetico cosmetico, IFormFile upload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (upload != null && upload.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await upload.CopyToAsync(memoryStream);
                            cosmetico.imagenProducto = memoryStream.ToArray();
                        }
                    }

                    _context.Update(cosmetico);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(VistaCosmetico));
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                // Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(cosmetico);
        }

        [HttpGet]
        public IActionResult DetalleCosmetico(int? codigo)
        {
            if (codigo == null)
            {
                return NotFound();
            }

            var cosmetico = _context.Cosmetico.Find(codigo);
            if (cosmetico == null)
            {
                return NotFound();
            }

            GetImage(cosmetico.Codigo);

            return View(cosmetico);
        }

        [HttpPost, ActionName("BorrarCosmetico")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarCosmetico(int? codigo)
        {
            var cosmetico = await _context.Cosmetico.FindAsync(codigo);
            if (cosmetico == null)
            {
                return View();
            }

            _context.Cosmetico.Remove(cosmetico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(VistaCosmetico));
        }
    }
}
