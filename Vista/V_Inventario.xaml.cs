using Byte_Coffee.Controlador;
using Byte_Coffee.Modelo;
using Byte_Coffee.Clases;
using System.Collections.Generic;
using System.Windows;

namespace Byte_Coffee.Vista
{
    public partial class Inventario : Window
    {
        private ControladorInventario controladorInventario;

        public Inventario()
        {
            InitializeComponent();
            controladorInventario = new ControladorInventario();
            List<Clases.Inventario> inventarios = controladorInventario.ObtenerDatosInventario();
            DataContext = new { Inventario = inventarios };
        }
    }
}
