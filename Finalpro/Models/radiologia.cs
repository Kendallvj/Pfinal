
using global::Finalpro.Models;
using System;
namespace Finalpro.Models
{
    public class Radiologia
    {
        public int IdRadiologia { get; set; }
        public int IdPaciente { get; set; }
        public string? NombrePaciente { get; set; }
        public string? EdadPaciente { get; set; }
        public DateTime FechaRadiologia { get; set; }
        public int IdEmpleado { get; set; }
        public string? AreaRadiograf { get; set; }
        public string? Resultados { get; set; }
        public string? Anotaciones { get; set; }

        public Pacientes Paciente { get; set; }
        public Empleados Empleado { get; set; }
    }
}
