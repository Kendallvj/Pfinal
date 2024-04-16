 using System;
namespace Finalpro.Models

{
    public class Citas
        {
            public int IdCita { get; set; }
            public string IdPaciente { get; set; }

            public DateTime FechaCita { get; set; }
            public string? TipoCita { get; set; }
            public string? MedicoAsignado { get; set; }
            public string? AreaCita { get; set; }
            public string? SeguroPaciente { get; set; }
            public string? RequisitosCita { get; set; }
            public string? NotasAdicionales { get; set; }

        }
    }
