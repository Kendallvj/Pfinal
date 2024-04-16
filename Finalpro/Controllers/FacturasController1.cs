using System.Linq;
using System.Threading.Tasks;
using Finalpro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Finalpro.Models;

namespace Finalpro.Controllers
{
    public class FacturasController : Controller
    {
        private readonly ApplicationDbContext _contexto;

        public FacturasController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        // GET: Facturas
        public async Task<IActionResult> Index()
        {
            var facturas = await _contexto.Facturas.ToListAsync();
            return View(facturas);
        }

        // GET: Facturas/Crear
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("IdFactura,IdPago,IdPaciente,FechaFactura,NombrePaciente,TipoCita,MedicoAsignado,AreaCita,SeguroPaciente,RequisitosCita,NotasAdicionales")] Facturas factura)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(factura);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(factura);
        }

        // GET: Facturas/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _contexto.Facturas.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }
            return View(factura);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("IdFactura,IdPago,IdPaciente,FechaFactura,NombrePaciente,TipoCita,MedicoAsignado,AreaCita,SeguroPaciente,RequisitosCita,NotasAdicionales")] Facturas factura)
        {
            if (id != factura.IdFactura)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _contexto.Update(factura);
                    await _contexto.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaExists(factura.IdFactura))
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
            return View(factura);
        }

        // GET: Facturas/Eliminar/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _contexto.Facturas.FirstOrDefaultAsync(m => m.IdFactura == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            var factura = await _contexto.Facturas.FindAsync(id);
            _contexto.Facturas.Remove(factura);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaExists(int id)
        {
            return _contexto.Facturas.Any(e => e.IdFactura == id);
        }
    }
}
