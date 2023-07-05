using Byte_Coffee.BD;
using Npgsql;
using System;
using System.Collections.Generic;
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
            string sentencia = "SELECT correo,clave FROM admin WHERE correo=@correo AND clave=@clave ";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia,conexion);
            comando.Parameters.AddWithValue("@correo", correo);
            comando.Parameters.AddWithValue("@clave", clave);
            NpgsqlDataReader reader = comando.ExecuteReader();
            if(reader.Read())
            {
                conxbd.CerrarConexion();
                return true;

            }
            else { 
            conxbd.CerrarConexion();
                return false; }
        }
    }
}
