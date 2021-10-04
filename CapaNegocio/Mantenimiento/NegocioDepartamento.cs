using System.Collections.Generic;
using CapaEntidad;
using CapaDatos;
using CapaServicios.ServicioDepartamento;
using CapaEntidad.Vistas;
using CapaServicios;
using CapaEntidad.Vistas_Detalles;


namespace CapaNegocio
{
    public static class NegocioDepartamento
    {
        public static string NegociarInsercion(Departamentos dpt)
        {
            GenerarCodigoDepartamento.GenerarCodigo(dpt);
            AdecuarCadenaDpt.AdecuarCadenaPropiedades(ref dpt);

            return MoldeNotificaciones.DevolverNotificacion(DatosDepartamento.InsertarDept(dpt));
        }

        public static string NegociarEliminado(int id)
        {
            return MoldeNotificaciones.DevolverNotificacion(DatosDepartamento.EliminarDpt(id));
        }

        public static string NegociarActualizado(Departamentos dpt)
        {
            GenerarCodigoDepartamento.GenerarCodigo(dpt);
            AdecuarCadenaDpt.AdecuarCadenaPropiedades(ref dpt);

            return MoldeNotificaciones.DevolverNotificacion(DatosDepartamento.ActualizarDpt(dpt));
        }

        public static List<Detalle_Empleado> NegociarEmpleadosVinculados(string nombrDpt)
        {
            return DatosDepartamento.EmpleadosVinculados(nombrDpt);
        }
     
        public static List<Detalle_Departamento> NegociarListado()
        {
            return DatosDepartamento.Listado();
        }

   
    }
}
