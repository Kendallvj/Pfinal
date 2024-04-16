
using System;

namespace Finalpro.Models
{
    public class SeguroDental
    {
        public int IdSeguro { get; set; }
        public int IdPaciente { get; set; }
        public string? NombreSeguro { get; set; }
        public string? NombreAsegurado { get; set; }
        public int NumeroPoliza { get; set; }
        public string? CoberturaRestric { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaVenci { get; set; }
        public string? EstadoPago { get; set; }

        public Pacientes Paciente { get; set; }
    }
}

