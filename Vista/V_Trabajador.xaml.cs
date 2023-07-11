﻿using Byte_Coffee.Clases;
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
    public partial class V_Trabajador : Window
    {
        private ControladorTrabajador controladorTrabajador;
        public V_Trabajador()
        {
            InitializeComponent();
            controladorTrabajador = new ControladorTrabajador();
            List<Trabajador> trabajadors = controladorTrabajador.ObtenerDatosTrabajador();
            listaTrabajadores.ItemsSource = trabajadors;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BbtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Button btnEliminar = (Button)sender;
            Trabajador trabajador = (Trabajador)btnEliminar.DataContext;
            int idTrabajador = trabajador.Id;

            controladorTrabajador.EliminarTrabajador(idTrabajador);

            List<Trabajador> trabajadores = controladorTrabajador.ObtenerDatosTrabajador();
            listaTrabajadores.ItemsSource = trabajadores;
        }
    }
}