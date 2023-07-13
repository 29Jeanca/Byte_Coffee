using Byte_Coffee.Clases;
using Byte_Coffee.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Coffee.Controlador
{
    public class ControladorReserva
    {
        ModeloReserva modelo_reserva;
        public ControladorReserva()
        {
            modelo_reserva = new ModeloReserva();
        }
        public List<Reserva> CargarReservas()
        {
            return modelo_reserva.CargarReservas();
        }
    }
}
