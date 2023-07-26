using Byte_Coffee.Modelo;


namespace Byte_Coffee.Controlador
{
    public class ControladorLogin
    {
        private readonly ModeloLogin modelo_login;

        public ControladorLogin()
        {
            modelo_login = new ModeloLogin();
        }

        public bool ValidarAdmin(string correo, string clave)
        {
            return modelo_login.ValidarAdmin(correo, clave);
        }

        public (int, string) TomarDatosCliente(string correo)
        {
            return modelo_login.TomarDatosCliente(correo);
        }

        public bool ValidarUsuario(string correo, string clave)
        {
            return modelo_login.ValidarUsuario(correo, clave);
        }
    }
}
