using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Coffee.Clases
{
    public class Sesion
    {
        public static int IdCliente { get; set; }
        public static string Nombre { get; set; }

        public static void IniciarSesion(int idCliente, string nombre)
        {
            IdCliente = idCliente;
            Nombre = nombre;
        }
    }
}
