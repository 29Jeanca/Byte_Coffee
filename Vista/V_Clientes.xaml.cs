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
    /// Lógica de interacción para V_Clientes.xaml
    /// </summary>
    public partial class V_Clientes : Window
    {
        private ControladorCliente controladorCliente;
        public V_Clientes()
        {
            InitializeComponent();
            controladorCliente = new ControladorCliente();
            List<Cliente> MostrarLista = controladorCliente.ClientesRegistrados();
            listaClientes.ItemsSource = MostrarLista;
            OrdenAlfabetico.Items.Add("A-Z");
            OrdenAlfabetico.Items.Add("Z-A");
            OrdenAlfabetico.Items.Add("Orden de inserción");
        }

        private void OrdenAlfabetico_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string orden = (string)OrdenAlfabetico.SelectedItem;
            if (orden == "A-Z")
            {
                List<Cliente> MostrarLista = controladorCliente.ClientesFiltrados("ASC");
                listaClientes.ItemsSource = MostrarLista;
            }
            else if (orden == "Z-A")
            {
                List<Cliente> ListaFiltrada = controladorCliente.ClientesFiltrados("DESC");
                listaClientes.ItemsSource = ListaFiltrada;
            }
            else
            {
                List<Cliente> MostrarLista = controladorCliente.ClientesRegistrados();
                listaClientes.ItemsSource = MostrarLista;
            }
        }
    }
}
