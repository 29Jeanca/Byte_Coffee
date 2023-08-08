using Byte_Coffee.BD;
using Byte_Coffee.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
namespace Byte_Coffee.Modelo
{
    public class ModeloPlatillo
    {
        private readonly ConxBD conxBD;

        public ModeloPlatillo()
        {
            conxBD = new ConxBD();
        }
        public void AgregarPlatillo(Platillo platillo)
        {
            NpgsqlConnection conexion = conxBD.EstablecerConexion();
            string sentencia = "INSERT INTO Platillo (nombre,categoria,precio,descripcion,imagen) VALUES(@nombre,@categoria,@precio,@descripcion,@imagen)";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
            comando.Parameters.AddWithValue("@nombre", platillo.Nombre);
            comando.Parameters.AddWithValue("@categoria", platillo.Categoria);
            comando.Parameters.AddWithValue("@precio", platillo.Precio);
            comando.Parameters.AddWithValue("@descripcion", platillo.Descripcion);
            comando.Parameters.AddWithValue("@imagen", platillo.Imagen);
            NpgsqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                _ = new Platillo()
                {
                    Nombre = lector.GetString(0),
                    Categoria = lector.GetString(1),
                    Precio = lector.GetDecimal(2),
                    Descripcion = lector.GetString(3),
                    Imagen = lector.GetString(4)
                };
            }
            conxBD.CerrarConexion();
        }
        public List<Platillo> CargarMenu()
        {
            List<Platillo> menu = new List<Platillo>();
            NpgsqlConnection conexion = conxBD.EstablecerConexion();
            NpgsqlCommand comando = new NpgsqlCommand("SELECT * FROM stored_procedures.cargar_menu()", conexion);
            NpgsqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Platillo platillo = new Platillo()
                {
                    Id = lector.GetInt32(0),
                    Nombre = lector.GetString(1),
                    Precio = lector.GetDecimal(2),
                    Descripcion = lector.GetString(3),
                    Imagen = lector.GetString(4),
                };
                menu.Add(platillo);
            }
            conxBD.CerrarConexion();
            return menu;
        }
        public List<Platillo> MenuMasPedidos()
        {
            List<Platillo> menu = new List<Platillo>();
            NpgsqlConnection conexion = conxBD.EstablecerConexion();
            string sentencia = "SELECT id_platillo,nombre,precio,descripcion,imagen FROM platillo INNER JOIN pedidos ON id_platillo_pedido=platillo.id_platillo GROUP BY platillo.id_platillo,platillo.nombre,platillo.precio,platillo.descripcion,platillo.imagen,platillo.imagen ORDER BY COUNT(pedidos.id_platillo_pedido) DESC LIMIT 8";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
            NpgsqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Platillo platillo = new Platillo()
                {
                    Id = lector.GetInt32(0),
                    Nombre = lector.GetString(1),
                    Precio = lector.GetDecimal(2),
                    Descripcion = lector.GetString(3),
                    Imagen = lector.GetString(4),
                };
                menu.Add(platillo);
            }
            conxBD.CerrarConexion();
            return menu;
        }
        public List<Platillo> ListaDePedidos(List<int> IdPedidosPlatillo)
        {
            List<Platillo> PedidosRealizados = new List<Platillo>();
            foreach (int id in IdPedidosPlatillo)
            {
                NpgsqlConnection conexion = conxBD.EstablecerConexion();
                string sentencia = "SELECT nombre,precio,imagen FROM platillo WHERE id_platillo=@id";
                NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
                comando.Parameters.AddWithValue("@id", id);
                NpgsqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Platillo platillo = new Platillo()
                    {
                        Nombre = lector.GetString(0),
                        Precio = lector.GetDecimal(1),
                        Imagen = lector.GetString(2)
                    };
                    PedidosRealizados.Add(platillo);
                }
                conxBD.CerrarConexion();
            }
            return PedidosRealizados;

        }
        public void CompletarPedido(List<int> IdPlatillosPedidos, int IdCliente)
        {
            DateTime time = DateTime.Now;
            string fecha = $"{time.Day}/{time.Month}/{time.Year}";
            string hora = $"{time.Hour}:{time.Minute}:{time.Second}";

            NpgsqlConnection conexion = conxBD.EstablecerConexion();
            string sentencia = "INSERT INTO pedido_completo(id_cliente,fecha_pedido,hora_pedido) VALUES(@id_cliente,@fecha_pedido,@hora_pedido) RETURNING id_pedido_completo";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
            comando.Parameters.AddWithValue("@id_cliente", IdCliente);
            comando.Parameters.AddWithValue("@fecha_pedido", fecha);
            comando.Parameters.AddWithValue("@hora_pedido", hora);
            int idPedidoCompleto = (int)comando.ExecuteScalar();
            conxBD.CerrarConexion();
            foreach (int IdPlatilloPedido in IdPlatillosPedidos)
            {
                conxBD.EstablecerConexion();
                sentencia = "INSERT INTO pedidos(id_platillo_pedido,id_cliente,fecha_pedido,hora_pedido,id_pedido_completo) VALUES(@id_platillo_pedido,@id_cliente,@fecha_pedido,@hora_pedido,@id_pedido_completo)";
                comando = new NpgsqlCommand(sentencia, conexion);
                comando.Parameters.AddWithValue("@id_platillo_pedido", IdPlatilloPedido);
                comando.Parameters.AddWithValue("@id_cliente", IdCliente);
                comando.Parameters.AddWithValue("@fecha_pedido", fecha);
                comando.Parameters.AddWithValue("@hora_pedido", hora);
                comando.Parameters.AddWithValue("@id_pedido_completo", idPedidoCompleto);
                comando.ExecuteReader();
                conxBD.CerrarConexion();
            }
            conxBD.CerrarConexion();
        }

    }

}

