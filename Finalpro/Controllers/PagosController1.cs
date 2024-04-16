using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Finalpro.Models;

namespace Finalpro.Controllers
{
    public class PagosController : Controller
    {
        private readonly ApplicationDbContext _contexto;

        public PagosController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        // GET: Pagos
        public async Task<IActionResult> Index()
        {
            var pagos = await _contexto.Pagos.ToListAsync();
            return View(pagos);
        }

        // GET: Pagos/Crear
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("IdPago,IdCita,FechaPago,MontoPago,MetodoPago,Descripcion")] Pagos pago)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(pago);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pago);
        }

        // GET: Pagos/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pago = await _contexto.Pagos.FindAsync(id);
            if (pago == null)
            {
                return NotFound();
            }
            return View(pago);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("IdPago,IdCita,FechaPago,MontoPago,MetodoPago,Descripcion")] Pagos pago)
        {
            if (id != pago.IdPago)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _contexto.Update(pago);
                    await _contexto.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagoExists(pago.IdPago))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pago);
        }

        // GET: Pagos/Eliminar/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pago = await _contexto.Pagos.FirstOrDefaultAsync(m => m.IdPago == id);
            if (pago == null)
            {
                return NotFound();
            }

            return View(pago);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            var pago = await _contexto.Pagos.FindAsync(id);
            _contexto.Pagos.Remove(pago);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagoExists(int id)
        {
            return _contexto.Pagos.Any(e => e.IdPago == id);
        }
    }
}
