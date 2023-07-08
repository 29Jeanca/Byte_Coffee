using Byte_Coffee.Clases;
using Byte_Coffee.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Coffee.Controlador
{
    public class ControladorInventario
    {
        private readonly ModeloInventario modelo_inventario;

        public ControladorInventario()
        {
            modelo_inventario = new ModeloInventario();
        }
        public List<Inventario> ObtenerDatosInventario()
        {
            return modelo_inventario.ObtenerDatosInventario();
        }
    }
}
