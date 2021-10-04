using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.Vistas
{
    public class Detalle_Empleado
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string cargo_n { get; set; }
        public int cargo_id { get; set; }
        public string departamento_n { get; set; }
        public int departamento_id { get; set; }
        public string estatus { get; set; }
        public string retrato { get; set; }
        public decimal salario { get; set; }
        public DateTime fecha_ingreso { get; set; }

    }
}
