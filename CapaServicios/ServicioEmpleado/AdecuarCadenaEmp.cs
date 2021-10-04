using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaServicios.ServicioEmpleado
{
    public class AdecuarCadenaEmp
    {
        public static void AdecuarCadenaPropiedades(ref Empleados emp)
        {
            emp.Nombre = (CultureInfo.InvariantCulture.TextInfo.ToTitleCase(emp.Nombre));
        }
    }
}
