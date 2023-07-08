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
        private ModeloInicio modeloInicio;

        public ControladorInicio()
        {
            modeloInicio = new ModeloInicio();
        }
        public int CantidadTrabajadores()
        {
            return modeloInicio.CantidadTrabajadores();
        }
        public int CantidadClientes()
        {
            return modeloInicio.CantidadClientes();
        }
        public int CantidadPlatillos()
        {
            return modeloInicio.CantidadPlatillos();
        }
    }
}
