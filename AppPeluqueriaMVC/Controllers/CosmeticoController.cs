using AppPeluqueriaMVC.Data;
using AppPeluqueriaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult CrearCosmetico()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearCosmetico(Cosmetico cosmetico)
        {
            if (ModelState.IsValid)
            {
                cosmetico.Created = DateTime.Now;
                _context.Cosmetico.Add(cosmetico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(VistaCosmetico));
            }
            return View();
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
        public async Task<IActionResult> EditarCosmetico(Cosmetico cosmetico)
        {
            if (ModelState.IsValid)
            {
                _context.Update(cosmetico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(VistaCosmetico));
            }
            return View();
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
