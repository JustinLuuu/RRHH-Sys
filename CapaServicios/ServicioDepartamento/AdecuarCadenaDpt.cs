using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaServicios.ServicioDepartamento
{
    public class AdecuarCadenaDpt
    {
        public static void AdecuarCadenaPropiedades(ref Departamentos dpt)
        {
           dpt.Nombre = (CultureInfo.InvariantCulture.TextInfo.ToTitleCase(dpt.Nombre));           
        }

    }
}
