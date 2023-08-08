using Byte_Coffee.BD;
using Byte_Coffee.Clases;
using Byte_Coffee.Controlador;
using Byte_Coffee.Vista.PantallaCarga;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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
        private ConxBD conxBD;
        public V_ListaPedidos(List<int> listaIdPlatillosPedidos)
        {
            InitializeComponent();
            conxBD = new ConxBD();
            controladorPlatillo = new ControladorPlatillo();
            ListaPedidos.ItemsSource = controladorPlatillo.ListaDePlatillosPedidos(listaIdPlatillosPedidos);
            NpgsqlConnection conexion = conxBD.EstablecerConexion();
            string sentencia = "SELECT SUM(precio) FROM platillo WHERE id_platillo = ANY(@listaIdPlatillosPedidos)";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
            comando.Parameters.AddWithValue("@listaIdPlatillosPedidos", listaIdPlatillosPedidos);
            decimal totalPrecios = (decimal)comando.ExecuteScalar();
            conxBD.CerrarConexion();
            TxtTotalPrecio.Text = totalPrecios.ToString();
        }

        private async void BtnCompletarPedido_Click(object sender, RoutedEventArgs e)
        {
            V_CargaCompletandoPedido v_CargaCompletandoPedido = new V_CargaCompletandoPedido();
            v_CargaCompletandoPedido.Show();
            this.IsEnabled = false;
            await Task.Delay(TimeSpan.FromSeconds(5));
            controladorPlatillo.CompletarPedido(Sesion.PlatillosPedidos, Sesion.IdCliente);
            v_CargaCompletandoPedido.Close();
            
        }
    }
}
