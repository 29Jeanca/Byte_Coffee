using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Coffee.Clases
{
    public class Trabajador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Apellido { get; set; }
        public string Puesto { get; set; }
        public string Horario { get; set; }
        public string Fecha_Contratacion { get; set; }
        public int Salario { get; set; }
        public bool SolicitarVacaciones(string fecha_incio, string fecha_fin)
        {
            return false;
        }
        public void VerInformacion() { }

        public void CalcularSueldo() { }
    }

}
