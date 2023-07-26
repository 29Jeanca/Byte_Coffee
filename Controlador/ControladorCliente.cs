using Byte_Coffee.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Coffee.Controlador
{
    public class ControladorCliente
    {
        private ModeloCliente modeloCiente;
        public ControladorCliente()
        {
            modeloCiente = new ModeloCliente();
        }
        public void AgregarCliente(Cliente cliente)
        {
            modeloCiente.AgregarCliente(cliente);

        }
        public bool ValidacionCampos(Cliente cliente)
        {
            return modeloCiente.ValidacionCampos(cliente);
        }

    }
}
