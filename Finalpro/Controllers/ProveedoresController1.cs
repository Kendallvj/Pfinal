using System.Linq;
using System.Threading.Tasks;
using Finalpro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Finalpro.Models;

namespace Finalpro.Controllers
{
    public class ProveedoresController : Controller
    {
        private readonly ApplicationDbContext _contexto;

        public ProveedoresController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        // GET: Proveedores
        public async Task<IActionResult> Index()
        {
            var proveedores = await _contexto.Proveedores.ToListAsync();
            return View(proveedores);
        }

        // GET: Proveedores/Crear
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("IdProveedor,NombreProveedor,TelefonoProveedor,EmailProveedor,DireccionProveedor,FechaContrato,SueldoProv")] Proveedores proveedor)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(proveedor);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proveedor);
        }

        // GET: Proveedores/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedor = await _contexto.Proveedores.FindAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return View(proveedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("IdProveedor,NombreProveedor,TelefonoProveedor,EmailProveedor,DireccionProveedor,FechaContrato,SueldoProv")] Proveedores proveedor)
        {
            if (id != proveedor.IdProveedor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _contexto.Update(proveedor);
                    await _contexto.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProveedorExists(proveedor.IdProveedor))
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
            return View(proveedor);
        }

        // GET: Proveedores/Eliminar/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedor = await _contexto.Proveedores.FirstOrDefaultAsync(m => m.IdProveedor == id);
            if (proveedor == null)
            {
                return NotFound();
            }

            return View(proveedor);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            var proveedor = await _contexto.Proveedores.FindAsync(id);
            _contexto.Proveedores.Remove(proveedor);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProveedorExists(int id)
        {
            return _contexto.Proveedores.Any(e => e.IdProveedor == id);
        }
    }
}
