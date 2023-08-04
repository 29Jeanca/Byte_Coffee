using Byte_Coffee.BD;
using Byte_Coffee.Clases;
using Npgsql;
using NpgsqlTypes;
using System.Collections.Generic;

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
            NpgsqlCommand comando = new NpgsqlCommand("SELECT * FROM stored_procedures.llenar_puestos()", conexion);
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
            NpgsqlCommand comando = new NpgsqlCommand("SELECT * FROM stored_procedures.filtrar_puesto(@p_puesto)", conexion);
            comando.Parameters.AddWithValue("@p_puesto", Puesto);
            NpgsqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Trabajador trabajador = new Trabajador()
                {
                    Id = lector.GetInt16(0),
                    Nombre = lector.GetString(1),
                    Puesto = lector.GetString(2),
                    Salario = lector.GetDecimal(3),
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
            NpgsqlCommand comando = new NpgsqlCommand("SELECT * FROM stored_procedures.detalles_trabajador()", conexion);
            NpgsqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Trabajador trabajador = new Trabajador()
                {
                    Id = lector.GetInt16(0),
                    Nombre = lector.GetString(1),
                    Puesto = lector.GetString(2),
                    Salario = lector.GetDecimal(3)
                };
                trabajadores.Add(trabajador);
            }
            conxBD.CerrarConexion();
            return trabajadores;
        }
        public void EliminarTrabajador(int id)
        {
            NpgsqlConnection conexion = conxBD.EstablecerConexion();
            NpgsqlCommand comando = new NpgsqlCommand("SELECT stored_procedures.eliminar_trabajador(@id)", conexion);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            conxBD.CerrarConexion();
        }
        public List<Trabajador> EditarTrabajador(int id)
        {
            List<Trabajador> trabajadors = new List<Trabajador>();
            NpgsqlConnection conexion = conxBD.EstablecerConexion();
            NpgsqlCommand comando = new NpgsqlCommand("SELECT stored_procedures.editar_trabajador(@id)", conexion);
            comando.Parameters.AddWithValue("@id", id);
            NpgsqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Trabajador trabajador = new Trabajador()
                {
                    Id = lector.GetInt32(0),
                    Correo = lector.GetString(1),
                    HoraEntrada = lector.GetString(2),
                    HoraSalida = lector.GetString(3),
                    Puesto = lector.GetString(4),
                    DiaEntrada = lector.GetString(5),
                    DiaSalida = lector.GetString(6),
                    Salario = lector.GetDecimal(7)
                };
                trabajadors.Add(trabajador);
            }
            conxBD.CerrarConexion();
            return trabajadors;
        }
        public List<Trabajador> DetallesTrabajador(int id)
        {
            NpgsqlConnection conexion = conxBD.EstablecerConexion();
            List<Trabajador> trabajadors = new List<Trabajador>();
            NpgsqlCommand comando = new NpgsqlCommand("SELECT * FROM stored_procedures.detalles_trabajador_completo(@p_id)", conexion);
            comando.Parameters.AddWithValue("@p_id", id);
            NpgsqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Trabajador trabajador = new Trabajador()
                {
                    Id = lector.GetInt32(0),
                    Nombre = lector.GetString(1),
                    Correo = lector.GetString(2),
                    HoraEntrada = lector.GetString(3),
                    HoraSalida = lector.GetString(4),
                    Imagen = lector.GetString(5),
                    FechaContratacion = lector.GetDateTime(6).ToString("dd/MM/yyyy"),
                    Edad = lector.GetInt32(7),
                    Puesto = lector.GetString(8),
                    DiaEntrada = lector.GetString(9),
                    DiaSalida = lector.GetString(10),
                    FechaNacimiento = lector.GetDateTime(11).ToString("dd/MM/yyyy"),
                    Salario = lector.GetDecimal(12)
                };
                trabajadors.Add(trabajador);

            }
            conxBD.CerrarConexion();
            return trabajadors;
        }
        public void AgregarTrabajador(Trabajador trabajador)
        {
            NpgsqlConnection conexion = conxBD.EstablecerConexion();
            NpgsqlCommand comando = new NpgsqlCommand("CALL stored_procedures.crear_trabajador(@nombre,@apellido1,@apellido2,@correo,@hora_entrada,@hora_salida,@imagen,@fecha_contratacion,@edad,@puesto,@dia_entrada,@dia_salida,@fecha_nacimiento,@salario)", conexion);
            comando.Parameters.AddWithValue("@nombre", trabajador.Nombre);
            comando.Parameters.AddWithValue("@apellido1", trabajador.Apellido1);
            comando.Parameters.AddWithValue("@apellido2", trabajador.Apellido2);
            comando.Parameters.AddWithValue("@correo", trabajador.Correo);
            comando.Parameters.AddWithValue("@hora_entrada", trabajador.HoraEntrada);
            comando.Parameters.AddWithValue("@hora_salida", trabajador.HoraSalida);
            comando.Parameters.AddWithValue("@imagen", trabajador.Imagen);
            comando.Parameters.AddWithValue("@fecha_contratacion", trabajador.FechaContratacion);
            comando.Parameters.AddWithValue("@edad", trabajador.Edad);
            comando.Parameters.AddWithValue("@puesto", trabajador.Puesto);
            comando.Parameters.AddWithValue("@dia_entrada", trabajador.DiaEntrada);
            comando.Parameters.AddWithValue("@dia_salida", trabajador.DiaSalida);
            comando.Parameters.AddWithValue("@fecha_nacimiento", trabajador.FechaNacimiento);
            comando.Parameters.AddWithValue("@salario", trabajador.Salario);
            NpgsqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                _ = new Trabajador()
                {
                    Nombre = lector.GetString(0),
                    Apellido1 = lector.GetString(1),
                    Apellido2 = lector.GetString(2),
                    Correo = lector.GetString(3),
                    HoraEntrada = lector.GetString(4),
                    HoraSalida = lector.GetString(5),
                    Imagen = lector.GetString(6),
                    FechaContratacion = lector.GetString(7),
                    Edad = lector.GetInt32(8),
                    Puesto = lector.GetString(9),
                    DiaEntrada = lector.GetString(10),
                    DiaSalida = lector.GetString(11),
                    FechaNacimiento = lector.GetString(12),
                    Salario = lector.GetDecimal(13)
                };

            }
            conxBD.CerrarConexion();
        }

        //public bool ValidacionCampos(Trabajador trabajador)
        //{
        //    NpgsqlConnection conexion = conxBD.EstablecerConexion();
        //    string sentencia = "SELECT correo_trabajador FROM trabajador WHERE correo_trabajador=@correo";
        //    NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
        //    comando.Parameters.AddWithValue("@correo", trabajador.Correo);
        //    NpgsqlDataReader lector = comando.ExecuteReader();
        //    if (string.IsNullOrEmpty(trabajador.Nombre) || string.IsNullOrEmpty(trabajador.Apellido1) || string.IsNullOrEmpty(trabajador.Correo) ||
        //        string.IsNullOrEmpty(trabajador.Puesto) || string.IsNullOrEmpty(trabajador.Horario) || string.IsNullOrEmpty(trabajador.Salario))
        //    {
        //        MessageBox.Show("Todos los campos deben ser completados.");
        //        conxBD.CerrarConexion();
        //        return false;
        //    }
        //    else if (!Regex.IsMatch(trabajador.Correo, emailRegex))
        //    {
        //        MessageBox.Show("El correo tiene un formato incorrecto");
        //        conxBD.CerrarConexion();

        //        return false;
        //    }
        //    else if (lector.Read())
        //    {
        //        MessageBox.Show("El correo ya existe");
        //        conxBD.CerrarConexion();
        //        return false;
        //    }
        //    else
        //    {
        //        MessageBox.Show("¡Trabajador Ingresado Correctamente!");
        //        conxBD.CerrarConexion();
        //        return true;
        //    }

        //}

    }
}