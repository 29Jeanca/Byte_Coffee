using Byte_Coffee.BD;
using Byte_Coffee.Clases;
using Byte_Coffee.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Coffee.Controlador
{
    public class ControladorPlatillo
    {
        private readonly ModeloPlatillo modeloPlatillo;

        public ControladorPlatillo()
        {
            modeloPlatillo = new ModeloPlatillo();
        }
        public void AgregarPlatillo(Platillo platillo)
        {
            modeloPlatillo.AgregarPlatillo(platillo);
        }
        public List<Platillo> CargarMenu()
        {
            return modeloPlatillo.CargarMenu();
        }
    }
}
