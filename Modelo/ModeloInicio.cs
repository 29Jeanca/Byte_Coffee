using Byte_Coffee.BD;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Coffee.Modelo
{
    public class ModeloInicio
    {
        private ConxBD conxbd;


        public ModeloInicio()
        {
            conxbd = new ConxBD();
        }
        public int CantidadTrabajadores()
        {
            NpgsqlConnection conexion = conxbd.EstablecerConexion();
            string sentencia = "SELECT COUNT(id) FROM trabajador";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
            object resultado = comando.ExecuteScalar();
            int cantidadTrabajadores = Convert.ToInt32(resultado);
            conxbd.CerrarConexion();
            return cantidadTrabajadores;
        }
        public int CantidadClientes()
        {
            NpgsqlConnection conexion = conxbd.EstablecerConexion();
            string sentencia = "SELECT COUNT(id) FROM cliente";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
            object resultado = comando.ExecuteScalar();
            int cantidadClientes = Convert.ToInt32(resultado);
            conxbd.CerrarConexion();
            return cantidadClientes;
        }
        public int CantidadPlatillos()
        {
            NpgsqlConnection conexion = conxbd.EstablecerConexion();
            string sentencia = "SELECT COUNT(id) FROM menu";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
            object resultado = comando.ExecuteScalar();
            int cantidadPlatillos = Convert.ToInt32(resultado);
            conxbd.CerrarConexion();
            return cantidadPlatillos;
        }

    }
}
