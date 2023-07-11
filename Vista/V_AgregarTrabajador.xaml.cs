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
    public partial class V_AgregarTrabajador : Window
    {
        private ControladorTrabajador controladorTrabajador;
        DateTime fechaActual = DateTime.Now;
        public V_AgregarTrabajador()
        {
            InitializeComponent();
            controladorTrabajador = new ControladorTrabajador();
        }

        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            int dia, mes, anio;
            string nombre = txtNombre.Text;
            string apellido1 = txtApellido1.Text;
            string apellido2 = txtApellido2.Text;
            string correo = txtCorreo.Text;
            string puesto = txtPuesto.Text;
            string horario = txtHorario.Text;
            string salario = txtSalario.Text;
            dia = fechaActual.Day;
            mes = fechaActual.Month;
            anio = fechaActual.Year;
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido1) || string.IsNullOrEmpty(correo) ||
       string.IsNullOrEmpty(puesto) || string.IsNullOrEmpty(horario) || string.IsNullOrEmpty(salario))
            {
                MessageBox.Show("Todos los campos deben ser completados.");
                return;
            }

            if (nombre.Length < 4 || apellido1.Length < 4 || correo.Length < 4 ||
                puesto.Length < 4 || horario.Length < 4 || salario.Length < 4)
            {
                MessageBox.Show("Todos los campos deben tener al menos 4 caracteres.");
                return;
            }

            Trabajador nuevoTrabajador = new Trabajador()
            {


                Nombre = nombre,
                Apellido1 = apellido1,
                Apellido2 = apellido2,
                Correo = correo,
                Puesto = puesto,
                Horario = horario,
                Fecha_Contratacion = $"{dia}/{mes}/{anio}",
                Salario = salario
            };

            controladorTrabajador.AgregarTrabajador(nuevoTrabajador);

        }
    }
}
