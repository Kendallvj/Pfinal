using System.Linq;
using System.Threading.Tasks;
using Finalpro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Finalpro.Models;

namespace Finalpro.Controllers
{
    public class EquiposOdontologicosController : Controller
    {
        private readonly ApplicationDbContext _contexto;

        public EquiposOdontologicosController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        // GET: EquiposOdontologicos
        public async Task<IActionResult> Index()
        {
            var equiposOdontologicos = await _contexto.EquiposOdontologicos.ToListAsync();
            return View(equiposOdontologicos);
        }

        // GET: EquiposOdontologicos/Crear
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("IdEquipoOdonto,NombreMaterial,IdProveedor,CantidadStock,EstadoEquipo,FechaAdquisicion,Costo,AreaEquipo,UltimoMantenimiento")] EquipoOdontologico equipoOdontologico)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(equipoOdontologico);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipoOdontologico);
        }

        // GET: EquiposOdontologicos/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipoOdontologico = await _contexto.EquiposOdontologicos.FindAsync(id);
            if (equipoOdontologico == null)
            {
                return NotFound();
            }
            return View(equipoOdontologico);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("IdEquipoOdonto,NombreMaterial,IdProveedor,CantidadStock,EstadoEquipo,FechaAdquisicion,Costo,AreaEquipo,UltimoMantenimiento")] EquipoOdontologico equipoOdontologico)
        {
            if (id != equipoOdontologico.IdEquipoOdonto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _contexto.Update(equipoOdontologico);
                    await _contexto.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipoOdontologicoExists(equipoOdontologico.IdEquipoOdonto))
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
            return View(equipoOdontologico);
        }

        // GET: EquiposOdontologicos/Eliminar/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipoOdontologico = await _contexto.EquiposOdontologicos.FirstOrDefaultAsync(m => m.IdEquipoOdonto == id);
            if (equipoOdontologico == null)
            {
                return NotFound();
            }

            return View(equipoOdontologico);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            var equipoOdontologico = await _contexto.EquiposOdontologicos.FindAsync(id);
            _contexto.EquiposOdontologicos.Remove(equipoOdontologico);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipoOdontologicoExists(int id)
        {
            return _contexto.EquiposOdontologicos.Any(e => e.IdEquipoOdonto == id);
        }
    }
}
