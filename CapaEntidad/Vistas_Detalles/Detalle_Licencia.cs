using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.Vistas_Detalles
{
   public class Detalle_Licencia
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string retrato { get; set; }
        public DateTime desde { get; set; }
        public DateTime hasta { get; set; }
        public string motivo { get; set; }
        public string comentario { get; set; }
    }
}
