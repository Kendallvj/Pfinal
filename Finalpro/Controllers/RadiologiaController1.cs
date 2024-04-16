using System.Linq;
using System.Threading.Tasks;
using Finalpro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Finalpro.Models;

namespace Finalpro.Controllers
{
    public class RadiologiaController : Controller
    {
        private readonly ApplicationDbContext _contexto;

        public RadiologiaController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        // GET: Radiologia
        public async Task<IActionResult> Index()
        {
            var radiologias = await _contexto.Radiologias.ToListAsync();
            return View(radiologias);
        }

        // GET: Radiologia/Crear
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("IdRadiologia,IdPaciente,NombrePaciente,EdadPaciente,FechaRadiologia,IdEmpleado,AreaRadiograf,Resultados,Anotaciones")] Radiologia radiologia)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(radiologia);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(radiologia);
        }

        // GET: Radiologia/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var radiologia = await _contexto.Radiologias.FindAsync(id);
            if (radiologia == null)
            {
                return NotFound();
            }
            return View(radiologia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("IdRadiologia,IdPaciente,NombrePaciente,EdadPaciente,FechaRadiologia,IdEmpleado,AreaRadiograf,Resultados,Anotaciones")] Radiologia radiologia)
        {
            if (id != radiologia.IdRadiologia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _contexto.Update(radiologia);
                    await _contexto.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RadiologiaExists(radiologia.IdRadiologia))
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
            return View(radiologia);
        }

        // GET: Radiologia/Eliminar/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var radiologia = await _contexto.Radiologias.FirstOrDefaultAsync(m => m.IdRadiologia == id);
            if (radiologia == null)
            {
                return NotFound();
            }

            return View(radiologia);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            var radiologia = await _contexto.Radiologias.FindAsync(id);
            _contexto.Radiologias.Remove(radiologia);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RadiologiaExists(int id)
        {
            return _contexto.Radiologias.Any(e => e.IdRadiologia == id);
        }
    }
}

