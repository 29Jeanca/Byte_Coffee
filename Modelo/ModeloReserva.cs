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
    public class ModeloReserva
    {
        private ConxBD conxBD;
        public ModeloReserva()
        {
            conxBD = new ConxBD();
        }
        public List<Reserva> CargarReservas()
        {
            List<Reserva> reservas = new List<Reserva>();
            NpgsqlConnection conexion = conxBD.EstablecerConexion();
            string sentencia = "SELECT fecha,hora,nombre_cliente FROM reserva";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
            NpgsqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Reserva reserva = new Reserva()
                {
                    Fecha = lector.GetString(0),
                    Hora = lector.GetString(1),
                    NombreCliente = lector.GetString(2)
                };
                reservas.Add(reserva);
            }
            return reservas;
        }
    }
}
