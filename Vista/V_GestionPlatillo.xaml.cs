using Byte_Coffee.BD;
using Byte_Coffee.Clases;
using Byte_Coffee.Controlador;
using Byte_Coffee.Modelo;
using Microsoft.Win32;
using Npgsql;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Byte_Coffee.Vista
{
    /// <summary>
    /// Lógica de interacción para V_GestionPlatillo.xaml
    /// </summary>
    public partial class V_GestionPlatillo : Window
    {
        private string imagenUrl;

        public V_GestionPlatillo()
        {
            InitializeComponent();
        }

        private async void BtnSeleccionarImagen_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp|Todos los archivos|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                imgPlatillo.Source = new BitmapImage(new Uri(imagePath));
                imagenUrl = await ImgurUploader.UploadImageAsync(imagePath);
            }
        }

        private void BtnAgregarPlatillo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(imagenUrl);
            string nombre = txtNombre.Text;
            string categoria = txtCategoria.Text;
            decimal precio = Convert.ToDecimal(txtPrecio.Text);
            string descripcion = txtDescripcion.Text;

            // Aquí puedes realizar la lógica para guardar los datos del platillo en la base de datos,
            // junto con la URL de la imagen almacenada en Imgur (imagenUrl).
            ConxBD conx = new ConxBD();
            NpgsqlConnection connec = conx.EstablecerConexion();
            string sentencia = "INSERT INTO platillo(imagen) VALUES(@imagen)";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia, connec);
            comando.Parameters.Add("@imagen", NpgsqlTypes.NpgsqlDbType.Text).Value = imagenUrl;
            comando.ExecuteNonQuery();
        }
    }
}