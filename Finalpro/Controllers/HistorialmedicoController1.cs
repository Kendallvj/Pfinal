using System.Linq;
using System.Threading.Tasks;
using Finalpro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Finalpro.Models;

namespace Finalpro.Controllers
{
    public class HistorialMedicoController : Controller
    {
        private readonly ApplicationDbContext _contexto;

        public HistorialMedicoController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        // GET: HistorialMedico
        public async Task<IActionResult> Index()
        {
            var historialesMedicos = await _contexto.HistorialesMedicos.ToListAsync();
            return View(historialesMedicos);
        }

        // GET: HistorialMedico/Crear
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("IdHistorial,IdPaciente,TelefonoPaciente,EmailPaciente,EnfermedadesPreexistentes,AlergiasPaciente,MedicamentosPaciente,OtrosAntecedentesMedicos,TipoSanguineo,HistorialCirugias,UltimaRevision")] HistorialMedico historialMedico)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(historialMedico);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(historialMedico);
        }

        // GET: HistorialMedico/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialMedico = await _contexto.HistorialesMedicos.FindAsync(id);
            if (historialMedico == null)
            {
                return NotFound();
            }
            return View(historialMedico);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("IdHistorial,IdPaciente,TelefonoPaciente,EmailPaciente,EnfermedadesPreexistentes,AlergiasPaciente,MedicamentosPaciente,OtrosAntecedentesMedicos,TipoSanguineo,HistorialCirugias,UltimaRevision")] HistorialMedico historialMedico)
        {
            if (id != historialMedico.IdHistorial)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _contexto.Update(historialMedico);
                    await _contexto.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistorialMedicoExists(historialMedico.IdHistorial))
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
            return View(historialMedico);
        }

        // GET: HistorialMedico/Eliminar/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialMedico = await _contexto.HistorialesMedicos.FirstOrDefaultAsync(m => m.IdHistorial == id);
            if (historialMedico == null)
            {
                return NotFound();
            }

            return View(historialMedico);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            var historialMedico = await _contexto.HistorialesMedicos.FindAsync(id);
            _contexto.HistorialesMedicos.Remove(historialMedico);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistorialMedicoExists(int id)
        {
            return _contexto.HistorialesMedicos.Any(e => e.IdHistorial == id);
        }
    }
}
