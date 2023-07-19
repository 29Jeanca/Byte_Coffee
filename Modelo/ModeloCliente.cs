using Byte_Coffee.BD;
using Byte_Coffee.Clases;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Coffee.Modelo
{
    public class ModeloCliente
    {
        private ConxBD conxBD;

        public ModeloCliente()
        {
            conxBD = new ConxBD();
        }
        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> ClientesRegistrados = new List<Cliente>();
            NpgsqlConnection conexion = conxBD.EstablecerConexion();

            string sentencia = "SELECT id,nombre,apellido1,num_telefonico,ultima_reserva FROM cliente";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
            NpgsqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Cliente cliente = new Cliente()
                {
                    Id = lector.GetInt32(0),
                    Nombre = lector.GetString(1),
                    Apellido1 = lector.GetString(2),
                    Num_Telefonico = lector.GetString(3),
                    UltimaReserva = lector.GetString(4)
                };
                ClientesRegistrados.Add(cliente);
            }
            conxBD.CerrarConexion();
            return ClientesRegistrados;
        }
        public List<Cliente> FiltrarOrdenAlfabetico(string filtro)
        {
            List<Cliente> ClientesFiltrados = new List<Cliente>();
            NpgsqlConnection conexion = conxBD.EstablecerConexion();
            string sentencia = $"SELECT id,nombre,apellido1,num_telefonico,ultima_reserva FROM cliente ORDER BY nombre {filtro}";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
            NpgsqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Cliente cliente = new Cliente()
                {
                    Id = lector.GetInt32(0),
                    Nombre = lector.GetString(1),
                    Apellido1 = lector.GetString(2),
                    Num_Telefonico = lector.GetString(3),
                    UltimaReserva = lector.GetString(4)
                };
                ClientesFiltrados.Add(cliente);

            }
            conxBD.CerrarConexion();
            return ClientesFiltrados;
        }
    }
}
