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
    public class NegocioPermisos
    {
        public static void NegociarPermiso(Permisos permiso)
        {
            DatosPermisos.DarPermiso(permiso);
        }

        public static List<Detalle_Permisos> NegociarEmpleadosPermiso()
        {
            return DatosPermisos.EmpleadosVacaciones();
        }

        public static List<Empleados> NegociarEmpleados()
        {
            return DatosPermisos.DevolverEmpleadosActivos();
        }
    }
}
