using System.Collections.Generic;
using CapaEntidad;
using CapaEntidad.Vistas;
using CapaDatos;
using CapaServicios.ServicioEmpleado;
using CapaServicios;

namespace CapaNegocio
{
    public static class NegocioEmpleado
    {
        public static string NegociarInsercion(Empleados emp)
        {
            AdecuarCadenaEmp.AdecuarCadenaPropiedades(ref emp);
            GenerarCodigoEmpleado.GenerarCodigo(ref emp);
            ObtenerFoto.SetearFoto(ref emp);
            FechaHoy.SetearFechaActual(ref emp);

            return MoldeNotificaciones.DevolverNotificacion(DatosEmpleado.InsertarEmpleado(emp));
        }

        public static string NegociarActualizado(Empleados emp)
        {
            AdecuarCadenaEmp.AdecuarCadenaPropiedades(ref emp);     
            GenerarCodigoEmpleado.GenerarCodigo(ref emp);

            return MoldeNotificaciones.DevolverNotificacion(DatosEmpleado.ActualizarEmpleado(emp));
        }

        public static string NegociarEliminado(int id)
        {
            return MoldeNotificaciones.DevolverNotificacion(DatosEmpleado.EliminarEmpleado(id));
        }

        public static (List<Detalle_Empleado>, string) NegociarFiltro(string generico)
        {           
            generico= generico.ToLower();

            return (generico != "activo" && generico != "inactivo") ?
            (DatosEmpleado.FiltroGeneral(generico), $"Resultado de \"{generico}\"..") :
            (DatosEmpleado.FiltroEstatus(generico), $"Empleados [ {generico}s ] encontrados..");
        }

        public static List<Detalle_Empleado> NegociarListado()
        {
            return DatosEmpleado.TodosEmpleados();
        }

    }
}
