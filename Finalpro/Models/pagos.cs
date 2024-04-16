
using System;

namespace Finalpro.Models
{
    public class Pagos
    {
        public int IdPago { get; set; }
        public int IdCita { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal MontoPago { get; set; }
        public string? MetodoPago { get; set; }
        public string? Descripcion { get; set; }

        public Citas Cita { get; set; }
    }
}
