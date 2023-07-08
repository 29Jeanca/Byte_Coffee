using Byte_Coffee.BD;
using Byte_Coffee.Clases;
using Byte_Coffee.Vista;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventario = Byte_Coffee.Clases.Inventario;

namespace Byte_Coffee.Modelo
{
    public class ModeloInventario
    {
        private ConxBD conxbd;

        public ModeloInventario()
        {
            conxbd = new ConxBD();
        }
        public List<Inventario> ObtenerDatosInventario()
        {
            List<Inventario> inventarios = new List<Inventario>();
            NpgsqlConnection conexion = conxbd.EstablecerConexion();
            string sentencia = "SELECT nombre,cantidad,precio,descripcion FROM inventario";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
            NpgsqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Inventario inventario = new Inventario
                {
                    Nombre = lector.GetString(0),
                    Cantidad = lector.GetInt32(1),
                    Precio = lector.GetInt32(2),
                    Descripcion = lector.GetString(3)
                };
                inventarios.Add(inventario);
            }
            conxbd.CerrarConexion();
            return inventarios;
        }

    }
}
