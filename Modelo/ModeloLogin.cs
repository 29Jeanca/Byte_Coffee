using Byte_Coffee.BD;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Coffee.Modelo
{
    public class ModeloLogin
    {
        private ConxBD conxbd = new ConxBD();

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
    }
}
