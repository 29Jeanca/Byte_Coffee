using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Coffee.Clases
{
    public class Inventario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public int Cantidad { get; set; }
        public Inventario() { }
        public void ActualizarPrecio(int nuevo_precio) { }
        public void ObtenerInformacion() { }
        public void ActualizarCantidad(int nuevo_cantidad) { }
    }
}
