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
    /// Lógica de interacción para V_LoginCliente.xaml
    /// </summary>
    public partial class V_LoginCliente : Window
    {
        private ControladorLogin controladorLogin;
        public V_LoginCliente()
        {
            InitializeComponent();
            controladorLogin = new ControladorLogin();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            V_PantallaCarga carga = new V_PantallaCarga();
            carga.Show();
            string correo = txtCorreo.Text.ToLower();
            string clave = TxtClave.Password;
            var resultadoCliente = controladorLogin.TomarDatosCliente(correo);
            if (await Task.Run(() => controladorLogin.ValidarUsuario(correo, clave)))
            {
                Sesion.IniciarSesion(resultadoCliente.Item1, resultadoCliente.Item2);
                V_Menu menu = new V_Menu();
                menu.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario no encontrado");
            }
            carga.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            V_CrearUsuario crearUsuario = new V_CrearUsuario();
            crearUsuario.Show();
            this.Close();
        }
    }
}
