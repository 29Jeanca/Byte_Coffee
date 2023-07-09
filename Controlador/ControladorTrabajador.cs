using Byte_Coffee.Clases;
using Byte_Coffee.Modelo;
using Byte_Coffee.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Coffee.Controlador
{
    public class ControladorTrabajador
    {
        private ModeloTrabajador modelo_trabajador;

        public ControladorTrabajador()
        {
            modelo_trabajador = new ModeloTrabajador();
        }
        public List<Trabajador> ObtenerDatosTrabajador()
        {
            return modelo_trabajador.ObtenerDatosTrabajador();
        }
        public void EliminarTrabajador(int id)
        {
            ModeloTrabajador modeloTrabajador = new ModeloTrabajador();
            modeloTrabajador.EliminarTrabajador(id);
        }
    }
}
