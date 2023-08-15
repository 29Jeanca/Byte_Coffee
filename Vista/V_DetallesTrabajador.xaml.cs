using Byte_Coffee.Clases;
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
    /// Lógica de interacción para V_DetallesTrabajador.xaml
    /// </summary>
    public partial class V_DetallesTrabajador : Window
    {
        private readonly ControladorTrabajador controladorTrabajador;

        public V_DetallesTrabajador(List<Trabajador> trabajadors)
        {

            InitializeComponent();
            controladorTrabajador = new ControladorTrabajador();
            DetallesTrabajador.ItemsSource = trabajadors;
        }

        private async void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            V_PantallaCarga carga = new V_PantallaCarga();
            carga.Show();
            var siNo = MessageBox.Show("¿Está seguro que desea eliminar al trabajador? Esta acción es irreversible", "IMPORTANTE", MessageBoxButton.YesNo);
            if (await Task.Run(() => siNo == MessageBoxResult.Yes))
            {
                Button btnEliminar = (Button)sender;
                Trabajador trabajador = (Trabajador)btnEliminar.DataContext;
                int idTrabajador = trabajador.Id;

                controladorTrabajador.EliminarTrabajador(idTrabajador);

                this.Close();
            }
            carga.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            V_Inicio inicio = new V_Inicio();
            inicio.Show();
            this.Close();
        }
    }
}
