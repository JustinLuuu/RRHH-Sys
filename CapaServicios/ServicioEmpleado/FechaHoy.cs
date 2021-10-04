using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaServicios.ServicioEmpleado
{
    public static class FechaHoy
    {
        public static void SetearFechaActual(ref Empleados emp)
        {
            emp.Fecha_Ingreso = DateTime.Now;
        }

    }
}
