using System;
using System.Collections.Generic;

namespace Finalpro.Models
{
    public class Pacientes
    {
        public int IdPaciente { get; set; }
        public string? NombrePaciente { get; set; }
        public string? ApellidoPaciente { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? TipoSanguineo { get; set; }
        public string? Alergias { get; set; }
        public string? GeneroPaciente { get; set; }
        public string? DomicilioPaciente { get; set; }
        public int TelefonoPaciente { get; set; }
        public string? EmailPaciente { get; set; }
        public int NumeroEmergencia { get; set; }

        public ICollection<Citas> Cita { get; set; }
        public ICollection<HistorialMedico>? HistorialesMedicos { get; set; }
       
    }
}
