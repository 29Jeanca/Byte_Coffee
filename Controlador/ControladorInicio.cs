using Byte_Coffee.Clases;
using Byte_Coffee.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Coffee.Controlador
{
    public class ControladorInicio
    {
        private ModeloInicio modelo_inicio;

        public ControladorInicio()
        {
            modelo_inicio = new ModeloInicio();
        }
        public List<Trabajador> GetTrabajadoresPorEdad()
        {
            return modelo_inicio.GetTrabajadoresPorEdad();
        }
        public List<Platillo> PlatillosPedidos()
        {
            return modelo_inicio.PlatillosPedidos();
        }
        public int CantidadTotalPedidos()
        {
            return modelo_inicio.CantidadTotalPedidos();
        }

    }
}
