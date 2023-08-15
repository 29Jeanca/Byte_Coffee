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
        private ControladorPlatillo controladorPlatillo;
        public V_GestionPlatillo()
        {
            InitializeComponent();
            controladorPlatillo = new ControladorPlatillo();
        }

        private async void BtnSubirImagen_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp|Todos los archivos|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                imgPlatillo.Source = new BitmapImage(new Uri(imagePath));
                imagenUrl = await SubirImagenImgur.UploadImageAsync(imagePath);
            }
        }

        private void BtnAgregarPlatillo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(imagenUrl);
            string nombre = TxtPlatillo.Text;
            string categoria = TxtCategoria.Text;
            decimal precio = decimal.Parse(TxtPrecioPlatillo.Text);
            string descripcion = TxtDescripcionPlatillo.Text;
            Platillo nuevoPlatillo = new Platillo()
            {
                Nombre = nombre,
                Categoria = categoria,
                Precio = precio,
                Descripcion = descripcion,
                Imagen = imagenUrl
            };
            controladorPlatillo.AgregarPlatillo(nuevoPlatillo);
            VaciarCampos();
            MessageBox.Show("Ingresado correctamente");
            V_Inicio inicio = new V_Inicio();
            inicio.Show();
            this.Close();
        }
        private void VaciarCampos()
        {
            TxtPlatillo.Text = "";
            TxtCategoria.Text = "";
            TxtPrecioPlatillo.Text = "";
            TxtDescripcionPlatillo.Text = "";
            imgPlatillo.Source = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            V_Inicio inicio = new V_Inicio();
            inicio.Show();
            this.Close();
        }
    }
}