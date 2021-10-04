using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaServicios.ServicioCargo
{
    public class AdecuaCadenaCarg
    {
        public static void AdecuarCadenaPropiedades(ref Cargos carg)
        {
            carg.Nombre = (CultureInfo.InvariantCulture.TextInfo.ToTitleCase(carg.Nombre));
        }
    }
}
