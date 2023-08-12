using Byte_Coffee.Controlador;
using System;
using System.Windows;
using LiveCharts;
using LiveCharts.Wpf;
using System.Linq;

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
            TxtCantPedidos.Text = controladorInicio.CantidadTotalPedidos().ToString();
        }



        private void V_Inicio_Loaded(object sender, RoutedEventArgs e)
        {
            FillAgePieChart();
            GraficoPlatosPedidos();
        }

        private void FillAgePieChart()
        {
            var trabajadoresPorEdad = controladorInicio.GetTrabajadoresPorEdad();

            SeriesCollection ageSeries = new SeriesCollection();

            foreach (var edad in trabajadoresPorEdad.GroupBy(t => t.Edad))
            {
                ageSeries.Add(new PieSeries
                {
                    Title = $"{edad.Key} años",
                    Values = new ChartValues<int> { edad.Count() }
                });
            }

            GraficoEdadTrabajadores.Series = ageSeries;
        }

        private void GraficoPlatosPedidos()
        {
            var platillosPorPrecio = controladorInicio.PlatillosPedidos();

            SeriesCollection cantPlatillos = new SeriesCollection();

            foreach (var platillo in platillosPorPrecio)
            {
                cantPlatillos.Add(new PieSeries
                {
                    Title = platillo.Nombre,
                    Values = new ChartValues<decimal> { platillo.Cantidad },
                    DataLabels = true
                });
            }

            GraficoPlatos.Series = cantPlatillos;
        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            V_AgregarTrabajador v_AgregarTrabajador = new V_AgregarTrabajador();
            v_AgregarTrabajador.Show();
            this.Close();
        }

        private void SelectAgregarPlatillo_Click(object sender, RoutedEventArgs e)
        {
            V_GestionPlatillo v_GestionPlatillo = new V_GestionPlatillo();
            v_GestionPlatillo.Show();
            this.Close();
        }

        private void SelectVerMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SelectVerTrabajadores_Click(object sender, RoutedEventArgs e)
        {
            V_Trabajador v_Trabajador = new V_Trabajador();
            v_Trabajador.Show();
            this.Close();
        }

        private void SelectAgregarTrabajador_Click(object sender, RoutedEventArgs e)
        {
            V_AgregarTrabajador v_AgregarTrabajador = new V_AgregarTrabajador();
            v_AgregarTrabajador.Show();
            this.Close();
        }
    }
}
