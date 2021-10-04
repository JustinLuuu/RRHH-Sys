using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos.Procesos;
using CapaEntidad.Vistas_Detalles;

namespace CapaNegocio.Procesos
{
     public class NegocioVacaciones
     {
         public static void NegociarVacaciones(Vacaciones vaca)
         {
            DatosVacaciones.DarVacacionesEmpleado(vaca);
         }

         public static List<Detalle_Vacaciones> NegociarEmpleadosConVacaciones()
        {
            return DatosVacaciones.EmpleadosVacaciones();
        }

        public static List<Empleados> NegociarTodosEmpleados()
        {
           return DatosVacaciones.DevolverEmpleadosActivos();
        }

     }

}
