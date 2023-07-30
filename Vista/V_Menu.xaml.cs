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
using System.Windows.Threading;

namespace Byte_Coffee.Vista
{
    /// <summary>
    /// Lógica de interacción para V_Menu.xaml
    /// </summary>
    public partial class V_Menu : Window
    {
        private readonly ControladorPlatillo controladorPlatillo;
        private readonly DispatcherTimer reloj;
        public V_Menu()
        {
            InitializeComponent();
            controladorPlatillo = new ControladorPlatillo();
            List<Platillo> menuCargado = controladorPlatillo.CargarMenu();
            listaMenuCompleto.ItemsSource = menuCargado;
            //var id = Sesion.IdCliente;
            //var nombre = Sesion.Nombre;
            NombreUsuario.Text = Sesion.Nombre;
            //MessageBox.Show($"Este es el id {id} y este es el nombre {nombre}");
            reloj = new DispatcherTimer();
            reloj.Interval = TimeSpan.FromSeconds(1);
            reloj.Tick += Reloj;
            reloj.Start();
            Loaded += V_Menu_Loaded;
        }
        private void V_Menu_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ENTRA");
            double anchoVentana = this.Width;
            Linea.X2 = anchoVentana;
        }
        private void Reloj(object sender, EventArgs e)
        {
            Hora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

    }
}
