using Byte_Coffee.Clases;
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
    /// Lógica de interacción para V_DetallesTrabajador.xaml
    /// </summary>
    public partial class V_DetallesTrabajador : Window
    {
        public V_DetallesTrabajador(List<Trabajador> trabajadors)
        {
            InitializeComponent();
            VistaTrabajador.ItemsSource = trabajadors;
        }
    }
}
