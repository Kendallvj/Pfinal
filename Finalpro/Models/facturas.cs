
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
namespace Finalpro.Models
{
    public class Facturas
    {
        public int IdFactura { get; set; }
        public int IdPago { get; set; }
        public int IdPaciente { get; set; }
        public DateTime FechaFactura { get; set; }
        public string? NombrePaciente { get; set; }
        public string? TipoCita { get; set; }
        public string? MedicoAsignado { get; set; }
        public string? AreaCita { get; set; }
        public string? SeguroPaciente { get; set; }
        public string? RequisitosCita { get; set; }
        public string? NotasAdicionales { get; set; }

        public Pacientes Paciente { get; set; }
        public Pagos Pago { get; set; }
    }
}

