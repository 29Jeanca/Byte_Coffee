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
    /// Lógica de interacción para V_Menu.xaml
    /// </summary>
    public partial class V_Menu : Window
    {
        public V_Menu()
        {
            InitializeComponent();
            var id = Sesion.IdCliente;
            var nombre = Sesion.Nombre;
            MessageBox.Show($"Este es el id{id} y este es el nombre{nombre}");
        }
    }
}
