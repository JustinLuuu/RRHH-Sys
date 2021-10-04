using System;
using System.Collections.Generic;
using CapaServicios;
using CapaEntidad;
using CapaDatos;
using CapaServicios.ServicioCargo;
using CapaEntidad.Vistas;
using CapaEntidad.Vistas_Detalles;

namespace CapaNegocio
{
    public static class NegocioCargo
    {
        public static string NegociarInsercion(Cargos crg)
        {
            AdecuaCadenaCarg.AdecuarCadenaPropiedades(ref crg);

            return MoldeNotificaciones.DevolverNotificacion(DatosCargo.InsertarCargo(crg));
        }

        public static string NegociarActualizado(Cargos crg)
        {
            AdecuaCadenaCarg.AdecuarCadenaPropiedades(ref crg);

            return MoldeNotificaciones.DevolverNotificacion(DatosCargo.ActualizarCargo(crg));
        }

        public static string NegociarEliminado(int id)
        {
           return MoldeNotificaciones.DevolverNotificacion(DatosCargo.EliminarCargo(id));
        }

        public static List<Detalle_Cargo> NegociarListado()
        {
            return DatosCargo.Listado();
        }

        public static List<Detalle_Empleado> NegociarEmpleadosVinculados(string nombrCrg)
        {
            return DatosCargo.EmpleadosVinculados(nombrCrg);
        }

    }

}
