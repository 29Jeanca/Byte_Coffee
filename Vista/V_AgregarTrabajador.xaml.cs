using Byte_Coffee.Clases;
using Byte_Coffee.Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using Byte_Coffee.Vista.PantallaCarga;
namespace Byte_Coffee.Vista
{
    /// <summary>
    /// Lógica de interacción para V_Trabajador.xaml
    /// </summary>
    public partial class V_AgregarTrabajador : Window
    {
        private ControladorTrabajador controladorTrabajador;
        DateTime fechaActual = DateTime.Now;
        private string imgUrl;
        private enum DiasLaborales
        {
            Lunes,
            Martes,
            Miércoles,
            Jueves,
            Viernes,
            Sábado,
            Domingo
        }
        public V_AgregarTrabajador()
        {
            InitializeComponent();
            controladorTrabajador = new ControladorTrabajador();
            Loaded += V_AgregarTrabajador_Load;

        }


        private void V_AgregarTrabajador_Load(object sender, EventArgs e)
        {
            DiasLaborales[] dias = (DiasLaborales[])Enum.GetValues(typeof(DiasLaborales));

            foreach (DiasLaborales dia in dias)
            {
                ComboDiaEntrada.Items.Add(dia);
                ComboDiaSalida.Items.Add(dia);
            }

            ComboDiaSalida.SelectedIndex = 0;
            ComboDiaEntrada.SelectedIndex = 0;
        }

        private async void BtnAgregarTrabajador_Click(object sender, RoutedEventArgs e)
        {
            V_PantallaCarga carga = new V_PantallaCarga();
            carga.Show();
            string nombre = TxtNombre.Text;
            string apellido1 = TxtApellido1.Text;
            string apellido2 = TxtApellido2.Text;
            string correo = TxtCorreo.Text;
            string hora_entrada = HoraEntrada.Text;
            string hora_salida = HoraSalida.Text;
            string puesto = TxtPuesto.Text;
            string dia_entrada = ComboDiaEntrada.Text;
            string dia_salida = ComboDiaSalida.Text;
            string fechaNacimiento = fecha_nacimiento.SelectedDate.Value.Date.ToString("dd/MM/yyyy");
            decimal salario = decimal.Parse(TxtSalario.Text);
            int edad = fechaActual.Year - fecha_nacimiento.SelectedDate.Value.Date.Year;
            int dia = fechaActual.Day;
            int mes = fechaActual.Month;
            int anio = fechaActual.Year;
            Trabajador nuevoTrabajador = new Trabajador()
            {

                Nombre = nombre,
                Apellido1 = apellido1,
                Apellido2 = apellido2,
                FechaNacimiento = fechaNacimiento,
                Edad = edad,
                Correo = correo,
                HoraEntrada = hora_entrada,
                HoraSalida = hora_salida,
                Imagen = imgUrl,
                FechaContratacion = new DateTime(anio, mes, dia).ToString(),
                Puesto = puesto,
                DiaEntrada = dia_entrada,
                DiaSalida = dia_salida,
                Salario = salario

            };
            await Task.Run(() => controladorTrabajador.AgregarTrabajador(nuevoTrabajador));

            carga.Close();
            V_Inicio inicio = new V_Inicio();
            inicio.Show();
            this.Close();

        }
        private async void BtnSubirImagen_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp|Todos los archivos|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                imgTrabajador.Source = new BitmapImage(new Uri(imagePath));
                imgUrl = await SubirImagenImgur.UploadImageAsync(imagePath);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            V_Inicio inicio = new V_Inicio();
            inicio.Show();
            this.Close();
        }
    }
}
