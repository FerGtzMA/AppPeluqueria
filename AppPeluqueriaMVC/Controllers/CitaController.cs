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
            return View(await _context.Cita.ToListAsync());
        }

        //[HttpGet]
        //public IActionResult CrearCita()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CrearCita(Cita cita)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(cita);
        //    }

        //    var maxId = await _context.Cita.MaxAsync(c => (int?)c.Id) ?? 0;
        //    cita.Id = maxId + 1;

        //    var cliente = await _context.Cliente.FindAsync(cita.Id_Cliente);
        //    var empleado = await _context.Empleado.FindAsync(cita.Id_Empleado);

        //    if (cliente == null || empleado == null)
        //    {
        //        if (cliente == null)
        //        {
        //            ModelState.AddModelError("Id_Cliente", "El cliente especificado no existe.");
        //        }
        //        if (empleado == null)
        //        {
        //            ModelState.AddModelError("Id_Empleado", "El empleado especificado no existe.");
        //        }
        //        return View(cita);
        //    }

        //    cita.Empleado = empleado;
        //    cita.Cliente = cliente;
        //    cita.Created = DateTime.Now;

        //    _context.Cita.Add(cita);
        //    await _context.SaveChangesAsync();

        //    return RedirectToAction(nameof(VistaCita));
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CrearCita(Cita cita)
        //{
        //    var ultimaCita = _context.Cita.OrderBy(c => c.Id).FirstOrDefault();
        //    if (ultimaCita != null)
        //    {
        //        var cliente = _context.Cliente.Find(cita.Id_Cliente);
        //        var empleado = _context.Empleado.Find(cita.Id_Empleado);
        //        if (cliente == null || empleado == null)
        //        {
        //            return NotFound();
        //        }
        //        cita.Id = ultimaCita.Id + 1;
        //        cita.Empleado = empleado;
        //        cita.Cliente = cliente;
        //        if (ModelState.IsValid)
        //        {
        //            cita.Created = DateTime.Now;
        //            _context.Cita.Add(cita);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(VistaCita));
        //        }
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //    return View();
        //}

        public IActionResult CrearCita()
        {
            var viewModel = new CitaViewModel
            {
                Empleados = _context.Empleado.Select(e => new SelectListItem
                {
                    Value = e.Id.ToString(),
                    Text = e.Nombre + " " + e.Apellido
                }).ToList(),
                Clientes = _context.Cliente.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Nombre + " " + c.Apellido
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearCita(CitaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.Cita.Created = DateTime.Now; // Asegurar que la fecha de creación está establecida

                // Asegúrate de que añades el objeto Cita al DbSet correcto
                _context.Cita.Add(viewModel.Cita);

                // Guarda los cambios en la base de datos
                await _context.SaveChangesAsync();

                // Redirecciona a la vista o controlador adecuado
                return RedirectToAction(nameof(VistaCita));
            }

            // Recargar la información necesaria para la vista en caso de un error
            viewModel.Empleados = _context.Empleado.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Nombre + " " + e.Apellido
            }).ToList();

            viewModel.Clientes = _context.Cliente.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Nombre + " " + c.Apellido
            }).ToList();

            // Devuelve la vista con el modelo original en caso de error
            return View(viewModel);
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
            if (ModelState.IsValid)
            {
                _context.Update(cita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(VistaCita));
            }
            return View();
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
