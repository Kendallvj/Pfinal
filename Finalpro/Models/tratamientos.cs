
using global::Finalpro.Models;
using System;
namespace Finalpro.Models
{
    public class Tratamientos
    {
        public int IdTratamiento { get; set; }
        public int IdPaciente { get; set; }
        public DateTime FechaInicio { get; set; }
        public string? DescripTratamiento { get; set; }
        public int IdEmpleado { get; set; }
        public decimal CostoTratamiento { get; set; }
        public string? EstadoTratamiento { get; set; }
        public string? TipoTratamiento { get; set; }
        public string? MedicamentosRecetados { get; set; }
        public string? DuracionTratamiento { get; set; }
        public string? RetiroMedicamentos { get; set; }

        public Pacientes Paciente { get; set; }
        public Empleados Empleado { get; set; }
    }
}
