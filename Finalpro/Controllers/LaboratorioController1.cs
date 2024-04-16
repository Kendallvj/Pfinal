using System.Linq;
using System.Threading.Tasks;
using Finalpro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Finalpro.Models;

namespace Finalpro.Controllers
{
    public class LaboratorioController : Controller
    {
        private readonly ApplicationDbContext _contexto;

        public LaboratorioController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        // GET: Laboratorio
        public async Task<IActionResult> Index()
        {
            var laboratorios = await _contexto.Laboratorios.ToListAsync();
            return View(laboratorios);
        }

        // GET: Laboratorio/Crear
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("IdLaboratorio,NombreLab,DireccionLab,TelefonoLab,EmailLab,EncargadoArea,IdEquipoOdonto,TipoAnalisis")] Laboratorio laboratorio)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(laboratorio);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(laboratorio);
        }

        // GET: Laboratorio/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laboratorio = await _contexto.Laboratorios.FindAsync(id);
            if (laboratorio == null)
            {
                return NotFound();
            }
            return View(laboratorio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("IdLaboratorio,NombreLab,DireccionLab,TelefonoLab,EmailLab,EncargadoArea,IdEquipoOdonto,TipoAnalisis")] Laboratorio laboratorio)
        {
            if (id != laboratorio.IdLaboratorio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _contexto.Update(laboratorio);
                    await _contexto.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaboratorioExists(laboratorio.IdLaboratorio))
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
            return View(laboratorio);
        }

        // GET: Laboratorio/Eliminar/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laboratorio = await _contexto.Laboratorios.FirstOrDefaultAsync(m => m.IdLaboratorio == id);
            if (laboratorio == null)
            {
                return NotFound();
            }

            return View(laboratorio);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            var laboratorio = await _contexto.Laboratorios.FindAsync(id);
            _contexto.Laboratorios.Remove(laboratorio);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaboratorioExists(int id)
        {
            return _contexto.Laboratorios.Any(e => e.IdLaboratorio == id);
        }
    }
}
