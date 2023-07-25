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
        public int CantidadClientes()
        {
            NpgsqlConnection conexion = conxbd.EstablecerConexion();
            NpgsqlCommand comando = new NpgsqlCommand("SELECT stored_procedures.cantidad_clientes()", conexion);
            int cantidadClientes = Convert.ToInt32(comando.ExecuteScalar());
            conxbd.CerrarConexion();
            return cantidadClientes;
        }
        public int CantidadTrabajadores()
        {
            NpgsqlConnection conexion = conxbd.EstablecerConexion();
            NpgsqlCommand comando = new NpgsqlCommand("SELECT stored_procedures.cantidad_trabajadores()", conexion);
            int cantidadTrabajadores = Convert.ToInt32(comando.ExecuteScalar());
            conxbd.CerrarConexion();
            return cantidadTrabajadores;
        }
        public int CantidadTotalPedidos()
        {
            NpgsqlConnection conexion = conxbd.EstablecerConexion();
            NpgsqlCommand comando = new NpgsqlCommand("", conexion);

            return 1;
        }


    }
}
