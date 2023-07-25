using Byte_Coffee.Controlador;
using MaterialDesignThemes.Wpf;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Byte_Coffee.Vista.PantallaCarga;
using System.Windows.Input;

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

        private async void btnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.AppStarting;
            V_PantallaCarga carga = new V_PantallaCarga();
            carga.Show();
            string correo = txtCorreo.Text.ToLower();
            string clave = txtClave.Password;

            if (await Task.Run(() => controlador.ValidarAdmin(correo, clave)))
            {

                V_Inicio inicio = new V_Inicio();
                inicio.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("NO FUNCA");
            }

            carga.Close();
        }

    }
}
