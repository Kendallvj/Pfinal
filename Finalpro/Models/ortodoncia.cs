
using global::Finalpro.Models;
using Finalpro.Models;
using System;

namespace Finalpro.Models
{
    public class Ortodoncia
    {
        public int IdPaciente { get; set; }
        public string? NombrePaciente { get; set; }
        public int EdadPaciente { get; set; }
        public string? SeguroPaciente { get; set; }
        public string? EstadoPaciente { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime InicioTratamiento { get; set; }
        public string? TipoOrtodoncico { get; set; }
        public int NumeroAlineadores { get; set; }
        public DateTime FechaCambio { get; set; }
        public int CitasRequeridas { get; set; }
        public int IdEquipoOdonto { get; set; }
        public string? Complicaciones { get; set; }
        public string? NotasAdicio { get; set; }

        public Pacientes Paciente { get; set; }
        public Empleados Empleado { get; set; }
        public EquipoOdontologico EquipoOdontologico { get; set; }
    }
}
