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
    public class ModeloTrabajador
    {
        private readonly ConxBD conxBD;

        public ModeloTrabajador()
        {
            conxBD = new ConxBD();
        }
        public List<Trabajador> ObtenerDatosTrabajador()
        {
            List<Trabajador> trabajadores = new List<Trabajador>();
            NpgsqlConnection conexion = conxBD.EstablecerConexion();
            string sentencia = "SELECT id,nombre,apellido1,puesto_trabajador,salario_trabajador FROM trabajador";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
            NpgsqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Trabajador trabajador = new Trabajador()
                {
                    Id = lector.GetInt16(0),
                    Nombre = lector.GetString(1),
                    Apellido1 = lector.GetString(2),
                    Puesto = lector.GetString(3),
                    Salario = lector.GetString(4)
                };
                trabajadores.Add(trabajador);
            }
            conxBD.CerrarConexion();
            return trabajadores;

        }
        public void EliminarTrabajador(int id)
        {
            NpgsqlConnection conexion = conxBD.EstablecerConexion();
            string sentencia = "DELETE FROM trabajador WHERE id = @id";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            conxBD.CerrarConexion();
        }

    }
}
