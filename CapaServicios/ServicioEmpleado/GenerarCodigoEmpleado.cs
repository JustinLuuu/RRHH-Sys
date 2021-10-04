using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaServicios.ServicioEmpleado
{
    public static class GenerarCodigoEmpleado
    {
       private readonly static Random digitosRandom = new Random();
       
        public static void GenerarCodigo(ref Empleados emp)
        {
            int digitosAleatorios = digitosRandom.Next(10000, 99999);
            emp.Codigo = emp.Nombre[0].ToString() + emp.Apellido[0].ToString() + digitosAleatorios.ToString();
        }

    }
}
