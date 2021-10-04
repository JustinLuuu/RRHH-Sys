using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Procesos;
using CapaServicios;
using CapaEntidad.Vistas_Detalles;
using CapaEntidad;
using System.Windows.Forms;


namespace CapaNegocio.Procesos
{
    public static class NegocioSalida
    {
        public static string NegociarSalida(Salidas salida)
        {
            return MoldeNotificaciones.DevolverNotificacion(Datos_Salida.DesactivarEmpleado(salida));
        }

        public static string NegociarActivar(int id)
        {
            return MoldeNotificaciones.DevolverNotificacion(Datos_Salida.ActivarEmpleado(id)); 
        }
    
        public static List<Detalle_Salida> NegociarDevolverEmpleados()
        {
            return Datos_Salida.DevolverEmpleados();
        }

    }
}
