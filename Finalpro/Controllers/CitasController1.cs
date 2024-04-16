using System.Linq;
using System.Threading.Tasks;
using Finalpro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Finalpro.Models;

namespace Finalpro.Controllers
{
    public class CitasController : Controller
    {
        private readonly ApplicationDbContext _contexto;

        public CitasController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        // GET: Citas
        public async Task<IActionResult> Index()
        {
            var citas = await _contexto.Cita.ToListAsync();
            return View(citas);
        }

        // GET: Citas/Crear
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("IdCita,FechaCita,TipoCita,MedicoAsignado,IdPaciente")] Citas cita)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(cita);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cita);
        }

        // GET: Citas/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _contexto.Cita.FindAsync(id);
            if (cita == null)
            {
                return NotFound();
            }
            return View(cita);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("IdCita,FechaCita,TipoCita,MedicoAsignado,IdPaciente")] Citas cita)
        {
            if (id != cita.IdCita)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _contexto.Update(cita);
                    await _contexto.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitaExists(cita.IdCita))
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
            return View(cita);
        }

        // GET: Citas/Eliminar/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _contexto.Cita.FirstOrDefaultAsync(m => m.IdCita == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            var cita = await _contexto.Cita.FindAsync(id);
            _contexto.Cita.Remove(cita);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitaExists(int id)
        {
            return _contexto.Cita.Any(e => e.IdCita == id);
        }
    }
}
