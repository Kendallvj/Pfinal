
using System;

namespace Finalpro.Models
{
    public class EquipoOdontologico
    {
        public int IdEquipoOdonto { get; set; }
        public string? NombreMaterial { get; set; }
        public int IdProveedor { get; set; }
        public int CantidadStock { get; set; }
        public string? EstadoEquipo { get; set; }
        public DateTime FechaAdquisicion { get; set; }
        public decimal Costo { get; set; }
        public string? AreaEquipo { get; set; }
        public DateTime UltimoMantenimiento { get; set; }

    
    }
}
