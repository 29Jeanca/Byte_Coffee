using Byte_Coffee.Controlador;
using System.Windows;

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
