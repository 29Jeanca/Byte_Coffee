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
                    Nombre = lector.GetString(0),
                    Precio = lector.GetDecimal(1),
                    Descripcion = lector.GetString(2),
                    Imagen = lector.GetString(3),
                };
                menu.Add(platillo);
            }
            conxBD.CerrarConexion();
            return menu;
        }
    }
}

