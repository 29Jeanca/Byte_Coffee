using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Byte_Coffee.BD
{
    public class ConxBD
    {
        NpgsqlConnection conexion = new NpgsqlConnection();
        /*
        static String servidor = "containers-us-west-138.railway.app";
        static String nombre_base_datos = "railway";
        static String usuario = "postgres";
        static String clave = "x2koH9jp9y2jl1w0YhC1";
        static String puerto = "5967";
        */
        static String servidor = "localhost";
        static String nombre_base_datos = "byte_coffee";
        static String usuario = "postgres";
        static String clave = "root";
        static String puerto = "5432";

        String urlConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + clave + ";" + "database=" + nombre_base_datos + ";";

        public NpgsqlConnection EstablecerConexion()
        {

            try
            {
                conexion.ConnectionString = urlConexion;
                conexion.Open();

            }

            catch (NpgsqlException e)
            {
                MessageBox.Show("No se pudo conectar a la base de datos de PostgreSQL, error: " + e.ToString());

            }

            return conexion;
        }
        public NpgsqlConnection CerrarConexion()
        {

            try
            {
                conexion.Close();

            }

            catch (NpgsqlException e)
            {
                MessageBox.Show("No se pudo cerrar la conexion a la base de datos de PostgreSQL, error: " + e.ToString());

            }

            return conexion;
        }
    }
}

