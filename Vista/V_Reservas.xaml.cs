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
    /// Lógica de interacción para V_Reservas.xaml
    /// </summary>
    public partial class V_Reservas : Window
    {
        readonly ControladorReserva controladorReserva;
        public V_Reservas()
        {
            InitializeComponent();
            controladorReserva = new ControladorReserva();
            List<Reserva> reservas = controladorReserva.CargarReservas();
            listaReservas.ItemsSource = reservas;
        }
    }
}
