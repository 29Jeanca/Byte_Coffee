using Byte_Coffee.BD;
using Byte_Coffee.Clases;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Byte_Coffee.Modelo
{
    public class ModeloTrabajador
    {
        private readonly ConxBD conxBD;
        private const string emailRegex = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                    + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)+)"
                    + @"(?<=[^\.])@(([a-z0-9]+-)?[a-z0-9]+\.)*[a-z]"
                    + @"{2,63}(\.[a-z]{2,})?$";
        public ModeloTrabajador()
        {
            conxBD = new ConxBD();
        }
        public List<string> LlenarComboBox()
        {
            NpgsqlConnection conexion = conxBD.EstablecerConexion();
            string sentencia = "SELECT DISTINCT puesto_trabajador FROM trabajador";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
            NpgsqlDataReader lector = comando.ExecuteReader();

            List<string> puestos = new List<string>();

            while (lector.Read())
            {
                string puesto = lector.GetString(0);
                puestos.Add(puesto);
            }
            puestos.Insert(0, "Todos");
            conxBD.CerrarConexion();
            return puestos;
        }
        public List<Trabajador> FiltrarPorPuesto(string Puesto)
        {
            List<Trabajador> trabajadors = new List<Trabajador>();
            NpgsqlConnection conexion = conxBD.EstablecerConexion();
            string sentencia = "SELECT id,nombre,apellido1,puesto_trabajador,salario_trabajador FROM trabajador WHERE puesto_trabajador=@puesto_trabajador";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
            comando.Parameters.AddWithValue("@puesto_trabajador", Puesto);
            NpgsqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Trabajador trabajador = new Trabajador()
                {
                    Id = lector.GetInt16(0),
                    Nombre = lector.GetString(1),
                    Apellido1 = lector.GetString(2),
                    Puesto = lector.GetString(3),
                    Salario = lector.GetString(4),
                };
                trabajadors.Add(trabajador);
            }
            conxBD.CerrarConexion();
            return trabajadors;
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
        public List<Trabajador> DetallesTrabajador(int id)
        {
            NpgsqlConnection conexion = conxBD.EstablecerConexion();
            List<Trabajador> trabajadors = new List<Trabajador>();
            string sentencia = "SELECT nombre,apellido1,apellido2,correo_trabajador,fecha_contratacion," +
                "horario_trabajador,puesto_trabajador,salario_trabajador FROM trabajador WHERE id= @id";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
            comando.Parameters.AddWithValue("@id", id);
            NpgsqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Trabajador trabajador = new Trabajador()
                {
                    Nombre = lector.GetString(0),
                    Apellido1 = lector.GetString(1),
                    Apellido2 = lector.GetString(2),
                    Correo = lector.GetString(3),
                    FechaContratacion = lector.GetString(4),
                    Horario = lector.GetString(5),
                    Puesto = lector.GetString(6),
                    Salario = lector.GetString(7)
                };
                trabajadors.Add(trabajador);

            }
            conxBD.CerrarConexion();
            return trabajadors;
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
                comando.Parameters.AddWithValue("@fecha_contratacion", trabajador.FechaContratacion);
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
                        FechaContratacion = lector.GetString(4),
                        Horario = lector.GetString(5),
                        Puesto = lector.GetString(6),
                        Salario = lector.GetString(7)
                    };
                }
                conxBD.CerrarConexion();
            }
        }
        public bool ValidacionCampos(Trabajador trabajador)
        {
            NpgsqlConnection conexion = conxBD.EstablecerConexion();
            string sentencia = "SELECT correo_trabajador FROM trabajador WHERE correo_trabajador=@correo";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
            comando.Parameters.AddWithValue("@correo", trabajador.Correo);
            NpgsqlDataReader lector = comando.ExecuteReader();
            if (string.IsNullOrEmpty(trabajador.Nombre) || string.IsNullOrEmpty(trabajador.Apellido1) || string.IsNullOrEmpty(trabajador.Correo) ||
                string.IsNullOrEmpty(trabajador.Puesto) || string.IsNullOrEmpty(trabajador.Horario) || string.IsNullOrEmpty(trabajador.Salario))
            {
                MessageBox.Show("Todos los campos deben ser completados.");
                conxBD.CerrarConexion();
                return false;
            }
            else if (!Regex.IsMatch(trabajador.Correo, emailRegex))
            {
                MessageBox.Show("El correo tiene un formato incorrecto");
                conxBD.CerrarConexion();

                return false;
            }
            else if (lector.Read())
            {
                MessageBox.Show("El correo ya existe");
                conxBD.CerrarConexion();
                return false;
            }
            else
            {
                MessageBox.Show("¡Trabajador Ingresado Correctamente!");
                conxBD.CerrarConexion();
                return true;
            }

        }

    }
}