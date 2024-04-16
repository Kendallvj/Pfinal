using System.Linq;
using System.Threading.Tasks;
using Finalpro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Finalpro.Models;

namespace Finalpro.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly ApplicationDbContext _contexto;

        public EmpleadosController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        // GET: Empleados
        public async Task<IActionResult> Index()
        {
            var empleados = await _contexto.Empleado.ToListAsync();
            return View(empleados);
        }

        // GET: Empleados/Crear
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("IdEmpleado,NombreEmpleado,ApellidoEmpleado,CargoEmpleado,TelefonoEmpleado,EmailEmpleado,SeguroEmpleado,FechaIngreso,Salario")] Empleados empleado)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(empleado);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }

        // GET: Empleados/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _contexto.Empleado.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("IdEmpleado,NombreEmpleado,ApellidoEmpleado,CargoEmpleado,TelefonoEmpleado,EmailEmpleado,SeguroEmpleado,FechaIngreso,Salario")] Empleados empleado)
        {
            if (id != empleado.IdEmpleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _contexto.Update(empleado);
                    await _contexto.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.IdEmpleado))
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
            return View(empleado);
        }

        // GET: Empleados/Eliminar/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _contexto.Empleado.FirstOrDefaultAsync(m => m.IdEmpleado == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            var empleado = await _contexto.Empleado.FindAsync(id);
            _contexto.Empleado.Remove(empleado);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
            return _contexto.Empleado.Any(e => e.IdEmpleado == id);
        }
    }
}
