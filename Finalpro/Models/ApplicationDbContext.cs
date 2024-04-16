using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Finalpro.Models;
using Finalpro.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Azure;

namespace Finalpro.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Propiedades DbSet para cada clase de modelo
        public DbSet<usuarios> Usuario { get; set; }
        public DbSet<Pacientes> Pacientes { get; set; }
        public DbSet<Citas> Cita { get; set; }
        public DbSet<Empleados> Empleado { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<EquipoOdontologico> EquiposOdontologicos { get; set; }
        public DbSet<HistorialMedico> HistorialesMedicos { get; set; }
        public DbSet<Laboratorio> Laboratorios { get; set; }
        public DbSet<Ortodoncia> Ortodoncias { get; set; }
        public DbSet<Radiologia> Radiologias { get; set; }
        public DbSet<SeguroDental> SegurosDentales { get; set; }
        public DbSet<Tratamientos> Tratamientos { get; set; }
        public DbSet<Pagos> Pagos { get; set; }
        public DbSet<Facturas> Facturas { get; set; }

    }





}
