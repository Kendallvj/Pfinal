
using System;

namespace Finalpro.Models
{
    public class Proveedores
    {
        public int IdProveedor { get; set; }
        public string? NombreProveedor { get; set; }
        public int TelefonoProveedor { get; set; }
        public string? EmailProveedor { get; set; }
        public string? DireccionProveedor { get; set; }
        public DateTime FechaContrato { get; set; }
        public decimal SueldoProv { get; set; }
    }
}
