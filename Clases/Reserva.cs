using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Coffee.Clases
{
    public class Reserva
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string NombreCliente { get; set; }

    }
}
