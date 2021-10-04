using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Procesos;
using CapaEntidad;
using CapaEntidad.Vistas_Detalles;

namespace CapaNegocio.Procesos
{
    public class NegocioLicencia
    {
        public static void NegociarLicencia(Licencias licencia)
        {
            DatosLicencia.DarLicencia(licencia);
        }

        public static List<Empleados> NegociarEmpleados()
        {
            return DatosLicencia.DevolverEmpleadosActivos();
        }

        public static List<Detalle_Licencia> NegociarEmpleadosLicencia()
        {
            return DatosLicencia.EmpleadosLicencia();
        }


    }
}
