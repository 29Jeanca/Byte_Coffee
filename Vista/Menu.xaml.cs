using Byte_Coffee.Clases;
using Byte_Coffee.Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Byte_Coffee.Vista
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        private ControladorPlatillo controladorPlatillo;
        public Menu()
        {
            InitializeComponent();
            controladorPlatillo = new ControladorPlatillo();
            List<Platillo> platillos = controladorPlatillo.CargarMenu();
            listaPlatillos.ItemsSource = platillos;
        }

    }
}
