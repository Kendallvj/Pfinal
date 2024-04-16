
using System;

namespace Finalpro.Models
{
    public class Laboratorio
    {
        public int IdLaboratorio { get; set; }
        public string? NombreLab { get; set; }
        public string? DireccionLab { get; set; }
        public int TelefonoLab { get; set; }
        public string? EmailLab { get; set; }
        public string? EncargadoArea { get; set; }
        public int IdEquipoOdonto { get; set; }
        public string? TipoAnalisis { get; set; }

        public EquipoOdontologico EquipoOdontologico { get; set; }
    }
}
