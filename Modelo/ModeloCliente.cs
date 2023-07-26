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

namespace Byte_Coffee.Controlador
{
    public class ModeloCliente
    {
        private ConxBD conxBD;
        private const string emailRegex = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                  + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)+)"
                  + @"(?<=[^\.])@(([a-z0-9]+-)?[a-z0-9]+\.)*[a-z]"
                  + @"{2,63}(\.[a-z]{2,})?$";
        public ModeloCliente()
        {
            conxBD = new ConxBD();
        }
        public void AgregarCliente(Cliente cliente)
        {
            if (ValidacionCampos(cliente))
            {
                NpgsqlConnection conexion = conxBD.EstablecerConexion();
                NpgsqlCommand comando = new NpgsqlCommand("call stored_procedures.crear_cliente(@nombre,@apellido1,@apellido2,@fecha_nacimiento,@fecha_Registro,@email,@clave)", conexion);
                comando.Parameters.AddWithValue("@nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@apellido1", cliente.Apellido1);
                comando.Parameters.AddWithValue("@apellido2", cliente.Apellido2);
                comando.Parameters.AddWithValue("@fecha_nacimiento", cliente.Fecha_Nacimiento);
                comando.Parameters.AddWithValue("@fecha_Registro", cliente.Fecha_Registro);
                comando.Parameters.AddWithValue("@email", cliente.Email);
                comando.Parameters.AddWithValue("@clave", cliente.Clave);
                NpgsqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    _ = new Cliente()
                    {
                        Nombre = lector.GetString(0),
                        Apellido1 = lector.GetString(1),
                        Apellido2 = lector.GetString(2),
                        Fecha_Nacimiento = lector.GetString(3),
                        Fecha_Registro = lector.GetString(4),
                        Email = lector.GetString(5),
                        Clave = lector.GetString(6),
                    };
                }
            }
        }
        public bool ValidacionCampos(Cliente cliente)
        {
            NpgsqlConnection conexion = conxBD.EstablecerConexion();
            string sentencia = "SELECT Email FROM clientes  WHERE email=@email LIMIT 1";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
            comando.Parameters.AddWithValue("@email", cliente.Email);
            NpgsqlDataReader lector = comando.ExecuteReader();
            if (string.IsNullOrEmpty(cliente.Nombre) || string.IsNullOrEmpty(cliente.Apellido1) || string.IsNullOrEmpty(cliente.Apellido2) ||
                string.IsNullOrEmpty(cliente.Email) || string.IsNullOrEmpty(cliente.Clave))
            {
                MessageBox.Show("Todos los campos deben ser completados.");
                conxBD.CerrarConexion();
                return false;
            }
            else if (!Regex.IsMatch(cliente.Email, emailRegex))
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
                MessageBox.Show("¡Usuario creado!");
                conxBD.CerrarConexion();
                return true;
            }
        }

    }
}
