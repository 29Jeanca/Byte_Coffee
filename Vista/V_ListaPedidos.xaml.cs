using Byte_Coffee.Controlador;
using Byte_Coffee.Vista.PantallaCarga;
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
    /// Lógica de interacción para V_ListaPedidos.xaml
    /// </summary>
    public partial class V_ListaPedidos : Window
    {
        private ControladorPlatillo controladorPlatillo;
        public V_ListaPedidos(List<int> listaIdPedidos)
        {
            InitializeComponent();
            controladorPlatillo = new ControladorPlatillo();
            ListaPedidos.ItemsSource = controladorPlatillo.ListaDePedidos(listaIdPedidos);
        }


    }
}
