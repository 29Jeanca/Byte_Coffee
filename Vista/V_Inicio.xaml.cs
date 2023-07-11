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
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Inicio : Window
    {
        private ControladorInicio controladorInicio;
        public Inicio()
        {

            DateTime date = DateTime.Now;
            InitializeComponent();
            controladorInicio = new ControladorInicio();
            int cantidadTrabajadores = controladorInicio.CantidadTrabajadores();
            int cantidadClientes = controladorInicio.CantidadClientes();
            txtTrabajadores.Text = cantidadTrabajadores.ToString();
            txtClientes.Text = cantidadClientes.ToString();
            int dia, mes, anio;
            dia = date.Day;
            mes = date.Month;
            anio = date.Year;
            txtfecha.Text = $"{dia}/{mes}/{anio}";
        }
        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            menuGrid.Visibility = (menuGrid.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
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


        private void BtnAgregarProduto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnReabastecerProducto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnVerInventario_Click(object sender, RoutedEventArgs e)
        {
            Inventario inventario = new Inventario();
            inventario.Show();
            this.Close();
        }
    }

}
