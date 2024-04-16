using System.Linq;
using System.Threading.Tasks;
using Finalpro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Finalpro.Models;

namespace Finalpro.Controllers
{
    public class OrtodonciaController : Controller
    {
        private readonly ApplicationDbContext _contexto;

        public OrtodonciaController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        // GET: Ortodoncia
        public async Task<IActionResult> Index()
        {
            var ortodoncias = await _contexto.Ortodoncias.ToListAsync();
            return View(ortodoncias);
        }

        // GET: Ortodoncia/Crear
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("IdPaciente,NombrePaciente,EdadPaciente,SeguroPacient,EstadoPacient,IdEmpleado,InicioTratamiento,TipoOrtodoncico,NumeroAlineadores,FechaCambio,CitasRequeridas,IdEquipoOdonto,Complicaciones,NotasAdicio")] Ortodoncia ortodoncia)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(ortodoncia);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ortodoncia);
        }

        // GET: Ortodoncia/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ortodoncia = await _contexto.Ortodoncias.FindAsync(id);
            if (ortodoncia == null)
            {
                return NotFound();
            }
            return View(ortodoncia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("IdPaciente,NombrePaciente,EdadPaciente,SeguroPacient,EstadoPacient,IdEmpleado,InicioTratamiento,TipoOrtodoncico,NumeroAlineadores,FechaCambio,CitasRequeridas,IdEquipoOdonto,Complicaciones,NotasAdicio")] Ortodoncia ortodoncia)
        {
            if (id != ortodoncia.IdPaciente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _contexto.Update(ortodoncia);
                    await _contexto.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrtodonciaExists(ortodoncia.IdPaciente))
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
            return View(ortodoncia);
        }

        // GET: Ortodoncia/Eliminar/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ortodoncia = await _contexto.Ortodoncias.FirstOrDefaultAsync(m => m.IdPaciente == id);
            if (ortodoncia == null)
            {
                return NotFound();
            }

            return View(ortodoncia);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            var ortodoncia = await _contexto.Ortodoncias.FindAsync(id);
            _contexto.Ortodoncias.Remove(ortodoncia);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrtodonciaExists(int id)
        {
            return _contexto.Ortodoncias.Any(e => e.IdPaciente == id);
        }
    }
}
