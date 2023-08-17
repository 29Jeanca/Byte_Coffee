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
    /// Lógica de interacción para V_Trabajador.xaml
    /// </summary>
    public partial class V_Trabajador : Window
    {
        private ControladorTrabajador controladorTrabajador;
        public V_Trabajador()
        {
            InitializeComponent();
            controladorTrabajador = new ControladorTrabajador();
            List<Trabajador> trabajadors = controladorTrabajador.ObtenerDatosTrabajador();
            listaTrabajadores.ItemsSource = trabajadors;
            Puestos.ItemsSource = controladorTrabajador.LlenarComboBox();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {


        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            var siNo = MessageBox.Show("¿Está seguro que desea eliminar al trabajador?", "IMPORTANTE", MessageBoxButton.YesNo);
            if (siNo == MessageBoxResult.Yes)
            {
                Button btnEliminar = (Button)sender;
                Trabajador trabajador = (Trabajador)btnEliminar.DataContext;
                int idTrabajador = trabajador.Id;

                controladorTrabajador.EliminarTrabajador(idTrabajador);

                List<Trabajador> trabajadores = controladorTrabajador.ObtenerDatosTrabajador();
                listaTrabajadores.ItemsSource = trabajadores;
            }
        }
        private void Puestos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string Puesto = (string)Puestos.SelectedItem;
            if (Puesto == "Todos")
            {
                List<Trabajador> ListaTodos = controladorTrabajador.ObtenerDatosTrabajador();
                listaTrabajadores.ItemsSource = ListaTodos;
            }
            else
            {
                List<Trabajador> ListaFiltrada = controladorTrabajador.FiltrarPorPuesto(Puesto);
                listaTrabajadores.ItemsSource = ListaFiltrada;
            }
        }

        private void btnDetalles_Click(object sender, RoutedEventArgs e)
        {
            Button btnDetalles = (Button)sender;
            Trabajador trabajador = (Trabajador)btnDetalles.DataContext;
            int idTrabajador = trabajador.Id;
            List<Trabajador> detallesTrabajador = controladorTrabajador.DetallesTrabajador(idTrabajador);

            V_DetallesTrabajador v_DetallesTrabajador = new V_DetallesTrabajador(detallesTrabajador);
            v_DetallesTrabajador.Show();


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            V_Inicio inicio = new V_Inicio();
            inicio.Show();
            this.Close();
        }
    }
}