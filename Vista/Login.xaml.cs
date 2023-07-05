using Byte_Coffee.Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private ControladorLogin controlador;
        public Login()
        {
            InitializeComponent();
            controlador = new ControladorLogin();
        }

        private void btnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            string correo = txtCorreo.Text;
            string clave = txtClave.Password;

            if (controlador.ValidarAdmin(correo, clave))
            {
                MessageBox.Show("FUNCA");
            }
            else
            {
                MessageBox.Show("NO FUNCA");
            }
            
        }
    }
}
