using System.Linq;
using System.Threading.Tasks;
using Finalpro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Finalpro.Models;

namespace Finalpro.Controllers
{
    public class SeguroDentalController : Controller
    {
        private readonly ApplicationDbContext _contexto;

        public SeguroDentalController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        // GET: SeguroDental
        public async Task<IActionResult> Index()
        {
            var segurosDental = await _contexto.SegurosDentales.ToListAsync();
            return View(segurosDental);
        }

        // GET: SeguroDental/Crear
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("IdSeguro,IdPaciente,NombreSeguro,NombreAsegurado,NumeroPoliza,CoberturaRestric,FechaInicio,FechaVenci,EstadoPago")] SeguroDental seguroDental)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(seguroDental);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(seguroDental);
        }

        // GET: SeguroDental/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seguroDental = await _contexto.SegurosDentales.FindAsync(id);
            if (seguroDental == null)
            {
                return NotFound();
            }
            return View(seguroDental);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("IdSeguro,IdPaciente,NombreSeguro,NombreAsegurado,NumeroPoliza,CoberturaRestric,FechaInicio,FechaVenci,EstadoPago")] SeguroDental seguroDental)
        {
            if (id != seguroDental.IdSeguro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _contexto.Update(seguroDental);
                    await _contexto.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeguroDentalExists(seguroDental.IdSeguro))
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
            return View(seguroDental);
        }

        // GET: SeguroDental/Eliminar/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seguroDental = await _contexto.SegurosDentales.FirstOrDefaultAsync(m => m.IdSeguro == id);
            if (seguroDental == null)
            {
                return NotFound();
            }

            return View(seguroDental);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            var seguroDental = await _contexto.SegurosDentales.FindAsync(id);
            _contexto.SegurosDentales.Remove(seguroDental);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeguroDentalExists(int id)
        {
            return _contexto.SegurosDentales.Any(e => e.IdSeguro == id);
        }
    }
}
