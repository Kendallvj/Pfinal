using System;
namespace Finalpro.Models
{
    public class Empleados
    {
        public int IdEmpleado { get; set; }
        public string? NombreEmpleado { get; set; }
        public string? ApellidoEmpleado { get; set; }
        public string? CargoEmpleado { get; set; }
        public int TelefonoEmpleado { get; set; }
        public string? EmailEmpleado { get; set; }
        public string? SeguroEmpleado { get; set; }
        public DateTime FechaIngreso { get; set; }
        public decimal Salario { get; set; }
    }
}

