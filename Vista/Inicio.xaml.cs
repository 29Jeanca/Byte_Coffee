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
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Inicio : Window
    {
        public Inicio()
        {
            InitializeComponent();
        }
        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            // Alternar visibilidad del menú lateral
            menuGrid.Visibility = (menuGrid.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para manejar el clic del botón "Inicio"
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Lógica para manejar el clic del botón "Configuración"
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Lógica para manejar el clic del botón "Ayuda"
        }

        private void btnTrabajadores_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClientes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPlatillos_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}
