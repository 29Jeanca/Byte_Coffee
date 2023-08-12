using Byte_Coffee.BD;
using Byte_Coffee.Clases;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
        public List<Trabajador> GetTrabajadoresPorEdad()
        {
            List<Trabajador> trabajadores = new List<Trabajador>();
            NpgsqlConnection conexion = conxbd.EstablecerConexion();
            using (var cmd = new NpgsqlCommand("SELECT nombre, edad FROM trabajador", conexion))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    trabajadores.Add(new Trabajador
                    {
                        Nombre = reader.GetString(0),
                        Edad = reader.GetInt32(1)
                    });
                }
            }
            conxbd.CerrarConexion();
            return trabajadores;
        }

        public List<Platillo> PlatillosPedidos()
        {
            List<Platillo> platillos = new List<Platillo>();
            NpgsqlConnection conexion = conxbd.EstablecerConexion();
            using (var cmd = new NpgsqlCommand("SELECT platillo.nombre,count(id_platillo_pedido) FROM pedidos INNER JOIN platillo ON pedidos.id_platillo_pedido=id_platillo  GROUP BY platillo.nombre ORDER BY count(id_platillo_pedido) DESC", conexion))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    platillos.Add(new Platillo
                    {
                        Nombre = reader.GetString(0),
                        Cantidad = reader.GetInt32(1)
                    });
                }
            }
            conxbd.CerrarConexion();
            return platillos;
        }
        public int CantidadTotalPedidos()
        {
            NpgsqlConnection conexion = conxbd.EstablecerConexion();
            string sentencia = "SELECT COUNT(id_pedido_completo) FROM pedido_completo";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
            int CantPedidos = Convert.ToInt32(comando.ExecuteScalar());
            conxbd.CerrarConexion();
            return CantPedidos;
        }


    }
}
