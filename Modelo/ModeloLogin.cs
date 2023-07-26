using Byte_Coffee.BD;
using Npgsql;
using System;

namespace Byte_Coffee.Modelo
{
    public class ModeloLogin
    {
        private readonly ConxBD conxbd;
        public ModeloLogin()
        {
            conxbd = new ConxBD();
        }
        public bool ValidarAdmin(string correo, string clave)
        {
            NpgsqlConnection conexion = conxbd.EstablecerConexion();
            NpgsqlCommand comando = new NpgsqlCommand("SELECT stored_procedures.validar_admin(@correo_admin,@clave_admin)", conexion);
            comando.Parameters.AddWithValue("@correo_admin", correo);
            comando.Parameters.AddWithValue("@clave_admin", clave);
            bool resultado = (bool)comando.ExecuteScalar();
            if (resultado)
            {
                conxbd.CerrarConexion();
                return true;
            }
            else
            {
                conxbd.CerrarConexion();
                return false;
            }
        }
        public (int, string) TomarDatosCliente(string correo)
        {
            NpgsqlConnection conexion = conxbd.EstablecerConexion();
            NpgsqlCommand comando = new NpgsqlCommand("SELECT * FROM stored_procedures.tomar_datos_usuario(@correo_usuario)", conexion);
            comando.Parameters.AddWithValue("@correo_usuario", correo);
            NpgsqlDataReader lector = comando.ExecuteReader();
            if (lector.Read())
            {
                int id = lector.GetInt32(0);
                string nombre = lector.GetString(1);
                conxbd.CerrarConexion();
                return (id, nombre);
            }
            else
            {
                conxbd.CerrarConexion();
                return (-1, null);
            }


        }
        public bool ValidarUsuario(string correo, string clave)
        {
            NpgsqlConnection conexion = conxbd.EstablecerConexion();
            NpgsqlCommand comando = new NpgsqlCommand("SELECT stored_procedures.validar_cliente(@_email_cliente, @_clave_cliente)", conexion);
            comando.Parameters.AddWithValue("@_email_cliente", correo);
            comando.Parameters.AddWithValue("@_clave_cliente", clave);
            bool resultado = (bool)comando.ExecuteScalar();
            if (resultado)
            {
                conxbd.CerrarConexion();
                return true;
            }
            else
            {
                conxbd.CerrarConexion();
                return false;
            }
        }
    }
}
