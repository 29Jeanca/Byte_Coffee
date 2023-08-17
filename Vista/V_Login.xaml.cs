using Byte_Coffee.Controlador;
using MaterialDesignThemes.Wpf;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Byte_Coffee.Vista.PantallaCarga;
using System.Windows.Input;
using Byte_Coffee.BD;
using Npgsql;
using System;
using Byte_Coffee.Clases;

namespace Byte_Coffee.Vista
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class V_Login : Window
    {
        private ControladorLogin controlador;
        private ConxBD conx;
        public V_Login()
        {
            InitializeComponent();
            controlador = new ControladorLogin();
            conx = new ConxBD();
        }

        private async void btnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.AppStarting;
            V_PantallaCarga carga = new V_PantallaCarga();
            carga.Show();
            string correo = txtCorreo.Text.ToLower();
            string clave = txtClave.Password;
            NpgsqlConnection conexion = conx.EstablecerConexion();
            string sentencia = "SELECT id FROM admin WHERE correo=@correo";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
            comando.Parameters.AddWithValue("@correo", correo);
            int idAdmin = Convert.ToInt32(comando.ExecuteScalar());
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