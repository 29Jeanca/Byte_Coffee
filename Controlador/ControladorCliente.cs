using Byte_Coffee.Clases;
using Byte_Coffee.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Coffee.Controlador
{
    public class ControladorCliente
    {
        private ModeloCliente modeloCliente;

        public ControladorCliente()
        {
            modeloCliente = new ModeloCliente();
        }
        public List<Cliente> ClientesRegistrados()
        {
            return modeloCliente.ObtenerClientes();
        }
        public List<Cliente> ClientesFiltrados(string filtro)
        {
            return modeloCliente.FiltrarOrdenAlfabetico(filtro);
        }
    }
}
