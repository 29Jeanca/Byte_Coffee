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
        public List<string> LlenarComboBox()
        {
            return modelo_trabajador.LlenarComboBox();
        }
        public List<Trabajador> FiltrarPorPuesto(string Puesto)
        {
            return modelo_trabajador.FiltrarPorPuesto(Puesto);
        }
        public void EliminarTrabajador(int id)
        {
            modelo_trabajador.EliminarTrabajador(id);
        }
        public void EditarTrabajdor(int id)
        {
            modelo_trabajador.EditarTrabajador(id);
        }
        public List<Trabajador> DetallesTrabajador(int id)
        {
            return modelo_trabajador.DetallesTrabajador(id);
        }
        public void AgregarTrabajador(Trabajador trabajador)
        {
            modelo_trabajador.AgregarTrabajador(trabajador);
        }
        //public bool ValidacionCampos(Trabajador trabajador)
        //{
        //    return modelo_trabajador.ValidacionCampos(trabajador);
        //}

    }
}