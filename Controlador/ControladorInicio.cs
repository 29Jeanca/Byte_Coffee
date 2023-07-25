using Byte_Coffee.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public int CantidadTrabajadores()
        {
            return modelo_inicio.CantidadTrabajadores();
        }
        public int CantidadClientes()
        {
            return modelo_inicio.CantidadClientes();
        }

    }
}
