using Byte_Coffee.Clases;
using Byte_Coffee.Controlador;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;

namespace Byte_Coffee.Vista
{
    /// <summary>
    /// Lógica de interacción para V_ListaPedidos.xaml
    /// </summary>
    public partial class V_ListaPedidos : Window
    {
        private readonly ControladorPlatillo controladorPlatillo;
        private DateTime fecha = DateTime.Now;
        public V_ListaPedidos(List<int> listaIdPlatillosPedidos)
        {
            InitializeComponent();
            controladorPlatillo = new ControladorPlatillo();
            ListaPedidos.ItemsSource = controladorPlatillo.ListaDePlatillosPedidos(listaIdPlatillosPedidos);
        }

        private void BtnCompletarPedido_Click(object sender, RoutedEventArgs e)
        {
            controladorPlatillo.CompletarPedido(Sesion.PlatillosPedidos, Sesion.IdCliente);
        }
    }
}
