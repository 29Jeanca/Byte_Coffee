using Byte_Coffee.BD;
using Byte_Coffee.Clases;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        public void AgregarTrabajador(Trabajador trabajador)
        {
            if (ValidacionCampos(trabajador))
            {
                NpgsqlConnection conexion = conxBD.EstablecerConexion();
                string sentencia = "INSERT INTO trabajador (nombre, apellido1, apellido2, correo_trabajador, fecha_contratacion, horario_trabajador, puesto_trabajador, salario_trabajador) VALUES (@nombre, @apellido1,@apellido2,@correo_trabajador,@fecha_contratacion,@horario_trabajador,@puesto_trabajador,@salario_trabajador)";
                NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
                comando.Parameters.AddWithValue("@nombre", trabajador.Nombre);
                comando.Parameters.AddWithValue("@apellido1", trabajador.Apellido1);
                comando.Parameters.AddWithValue("@apellido2", trabajador.Apellido2);
                comando.Parameters.AddWithValue("@correo_trabajador", trabajador.Correo);
                comando.Parameters.AddWithValue("@fecha_contratacion", trabajador.Fecha_Contratacion);
                comando.Parameters.AddWithValue("@horario_trabajador", trabajador.Horario);
                comando.Parameters.AddWithValue("@puesto_trabajador", trabajador.Puesto);
                comando.Parameters.AddWithValue("@salario_trabajador", trabajador.Salario);
                NpgsqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    _ = new Trabajador()
                    {
                        Nombre = lector.GetString(0),
                        Apellido1 = lector.GetString(1),
                        Apellido2 = lector.GetString(2),
                        Correo = lector.GetString(3),
                        Fecha_Contratacion = lector.GetString(4),
                        Horario = lector.GetString(5),
                        Puesto = lector.GetString(6),
                        Salario = lector.GetString(7)
                    };
                }
            }
        }
        public bool ValidacionCampos(Trabajador trabajador)
        {
            if (string.IsNullOrEmpty(trabajador.Nombre) || string.IsNullOrEmpty(trabajador.Apellido1) || string.IsNullOrEmpty(trabajador.Correo) ||
                string.IsNullOrEmpty(trabajador.Puesto) || string.IsNullOrEmpty(trabajador.Horario) || string.IsNullOrEmpty(trabajador.Salario))
            {
                MessageBox.Show("Todos los campos deben ser completados.");
                return false;
            }
            else
            {
                return true;
            }

        }

    }
}