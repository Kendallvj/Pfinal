
using System;

namespace Finalpro.Models
{
    public class HistorialMedico
    {
        public int IdHistorial { get; set; }
        public int IdPaciente { get; set; }
        public int TelefonoPaciente { get; set; }
        public string? EmailPaciente { get; set; }
        public string? EnfermedadesPreexistentes { get; set; }
        public string? AlergiasPaciente { get; set; }
        public string? MedicamentosPaciente { get; set; }
        public string? OtrosAntecedentesMedicos { get; set; }
        public string? TipoSanguineo { get; set; }
        public string? HistorialCirugias { get; set; }
        public DateTime UltimaRevision { get; set; }

        public Pacientes Paciente { get; set; }
    }
}
