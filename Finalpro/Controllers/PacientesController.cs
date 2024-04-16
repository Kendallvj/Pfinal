using System.Linq;
using Finalpro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Finalpro.Models;

namespace Finalpro.Controllers
{
    public class PacientesController : Controller
    {
        private readonly ApplicationDbContext _contexto; 

        public PacientesController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        // GET: Pacientes
        public IActionResult Index()
        {
            var pacientes = _contexto.Pacientes.ToList();
            return View(pacientes);
        }

        // GET: Pacientes/Crear
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear([Bind("IdPaciente,NombrePaciente,ApellidoPaciente,FechaNaciPaciente,TipoSanguineo,Alergias,GeneroPaciente,DomicilioPaciente,TelefonoPaciente,EmailPaciente,NumeroEmergencia")] Pacientes paciente)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(paciente);
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }

        // GET: Pacientes/Editar/5
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = _contexto.Pacientes.Find(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, [Bind("IdPaciente,NombrePaciente,ApellidoPaciente,FechaNaciPaciente,TipoSanguineo,Alergias,GeneroPaciente,DomicilioPaciente,TelefonoPaciente,EmailPaciente,NumeroEmergencia")] Pacientes paciente)
        {
            if (id != paciente.IdPaciente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _contexto.Update(paciente);
                    _contexto.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteExists(paciente.IdPaciente))
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
            return View(paciente);
        }

        // GET: Pacientes/Eliminar/5
        public IActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = _contexto.Pacientes.Find(id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmarEliminar(int id)
        {
            var paciente = _contexto.Pacientes.Find(id);
            _contexto.Pacientes.Remove(paciente);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool PacienteExists(int id)
        {
            return _contexto.Pacientes.Any(p => p.IdPaciente == id);
        }
    }
}
