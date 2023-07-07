using Byte_Coffee.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Coffee.Controlador
{
    public class ControladorLogin
    {
        private ModeloLogin modelo_login;

        public ControladorLogin()
        {
            modelo_login = new ModeloLogin();
        }

        public bool ValidarAdmin(string correo, string clave)
        {
            return modelo_login.ValidarAdmin(correo, clave);
        }
    }
}
