using System;

namespace Finalpro.Models
{
    public class usuarios
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? Id { get; internal set; }
    }
}
