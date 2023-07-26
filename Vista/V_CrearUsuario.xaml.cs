using Byte_Coffee.Clases;
using Byte_Coffee.Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Application = System.Windows.Application;

namespace Byte_Coffee.Vista
{
    /// <summary>
    /// Lógica de interacción para V_CrearUsuario.xaml
    /// </summary>
    public partial class V_CrearUsuario : Window
    {
        private ControladorCliente controladorCliente;
        public V_CrearUsuario()
        {
            InitializeComponent();
            controladorCliente = new ControladorCliente();
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

        private void btnSign_Click(object sender, RoutedEventArgs e)
        {
            DateTime fechaActual = DateTime.Now;
            string txt = fecha_nacimiento.SelectedDate.Value.Date.ToString("dd/MM/yyyy");
            int dia, mes, year;
            string nombre = txtNombre.Text;
            string apellido1 = txtApellido1.Text;
            string apellido2 = txtApellido2.Text;
            string fnacimiento = txt;
            string correo = txtcorreo.Text;
            string clave = txtclave.Password;
            dia = fechaActual.Day;
            mes = fechaActual.Month;
            year = fechaActual.Year;
            ValidacionCampos();
            Cliente nuevoCliente = new Cliente()
            {

                Nombre = nombre,
                Apellido1 = apellido1,
                Apellido2 = apellido2,
                Fecha_Nacimiento = fnacimiento,
                Fecha_Registro = $"{dia}/{mes}/{year}",
                Email = correo,
                Clave = clave,
            };

            controladorCliente.AgregarCliente(nuevoCliente);

            V_LoginCliente inicio = new V_LoginCliente();
            inicio.Show();
            this.Close();

        }
        private bool ValidacionCampos()
        {
            string nombre = txtNombre.Text;
            string apellido1 = txtApellido1.Text;
            string apellido2 = txtApellido2.Text;
            string correo = txtcorreo.Text;
            string clave = txtclave.Password;
            Cliente cliente = new Cliente()
            {
                Nombre = nombre,
                Apellido1 = apellido1,
                Apellido2 = apellido2,
                Email = correo,
                Clave = clave

            };
            return controladorCliente.ValidacionCampos(cliente);

        }
    }
}
