using Byte_Coffee.BD;
using Byte_Coffee.Controlador;
using Npgsql;
using System;
using System.Collections;
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
    /// Lógica de interacción para V_Inicio.xaml
    /// </summary>
    public partial class V_Inicio : Window
    {
        private ControladorInicio controladorInicio;
        public V_Inicio()
        {
            InitializeComponent();
            DateTime fechaActual = DateTime.Now;
            int dia, mes, anio;
            dia = fechaActual.Day;
            mes = fechaActual.Month;
            anio = fechaActual.Year;
            string fechaCompleta = $"{dia}/{mes}/{anio}";
            txtFecha.Text = fechaCompleta;
            controladorInicio = new ControladorInicio();
            Loaded += V_Inicio_Loaded;
        }



        private void V_Inicio_Loaded(object sender, RoutedEventArgs e)
        {
            MgraficoCircularClientes();
            MgraficoCircularTrabajadores();
        }

        private void MgraficoCircularClientes()
        {
            GraficoCircularClientes.Series["Clientes"].Points.Clear();
            GraficoCircularClientes.Series["Clientes"].Points.AddXY("Clientes", controladorInicio.CantidadClientes());
        }
        private void MgraficoCircularTrabajadores()
        {
            GraficoCircularTrabajadores.Series["Trabajadores"].Points.Clear();
            GraficoCircularTrabajadores.Series["Trabajadores"].Points.AddXY("Trabajadores", controladorInicio.CantidadTrabajadores());
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            V_AgregarTrabajador v_AgregarTrabajador = new V_AgregarTrabajador();
            v_AgregarTrabajador.Show();
            this.Close();
        }
    }
}
