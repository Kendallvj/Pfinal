using System.Linq;
using System.Threading.Tasks;
using Finalpro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Finalpro.Models;

namespace Finalpro.Controllers
{
    public class TratamientosController : Controller
    {
        private readonly ApplicationDbContext _contexto;

        public TratamientosController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        // GET: Tratamientos
        public async Task<IActionResult> Index()
        {
            var tratamientos = await _contexto.Tratamientos.ToListAsync();
            return View(tratamientos);
        }

        // GET: Tratamientos/Crear
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("IdTratamiento,IdPaciente,FechaInicio,DescripTratamiento,IdEmpleado,CostoTratamiento,EstadoTratamiento,TipoTratamiento,MedicamentosRecetados,DuracionTratamiento,RetiroMedicamentos")] Tratamientos tratamiento)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(tratamiento);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tratamiento);
        }

        // GET: Tratamientos/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tratamiento = await _contexto.Tratamientos.FindAsync(id);
            if (tratamiento == null)
            {
                return NotFound();
            }
            return View(tratamiento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("IdTratamiento,IdPaciente,FechaInicio,DescripTratamiento,IdEmpleado,CostoTratamiento,EstadoTratamiento,TipoTratamiento,MedicamentosRecetados,DuracionTratamiento,RetiroMedicamentos")] Tratamientos tratamiento)
        {
            if (id != tratamiento.IdTratamiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _contexto.Update(tratamiento);
                    await _contexto.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TratamientoExists(tratamiento.IdTratamiento))
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
            return View(tratamiento);
        }

        // GET: Tratamientos/Eliminar/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tratamiento = await _contexto.Tratamientos.FirstOrDefaultAsync(m => m.IdTratamiento == id);
            if (tratamiento == null)
            {
                return NotFound();
            }

            return View(tratamiento);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            var tratamiento = await _contexto.Tratamientos.FindAsync(id);
            _contexto.Tratamientos.Remove(tratamiento);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TratamientoExists(int id)
        {
            return _contexto.Tratamientos.Any(e => e.IdTratamiento == id);
        }
    }
}

