using AppPeluqueriaMVC.Data;
using AppPeluqueriaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AppPeluqueriaMVC.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ClienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> VistaCliente()
        {
            return View(await _context.Cliente.ToListAsync());
        }

        [HttpGet]
        public IActionResult CrearCliente()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.Created = DateTime.Now;
                _context.Cliente.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(VistaCliente));
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditarCliente(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = _context.Cliente.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Update(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(VistaCliente));
            }
            return View();
        }

        [HttpGet]
        public IActionResult DetalleCliente(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = _context.Cliente.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost, ActionName("BorrarCliente")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarClienteAccion(int? id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return View();
            }

            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(VistaCliente));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
