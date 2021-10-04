using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaEntidad.Vistas;
using CapaEntidad.Vistas_Detalles;


namespace CapaDatos.Procesos
{
    public class DatosVacaciones
    {
        public static void DarVacacionesEmpleado(Vacaciones vaca)
        {
            try
            {
                using (var bd = new RecursosHumanosEntities())
                {
                    vaca.Año_Correspondiente = Convert.ToInt32(DateTime.Today.Year);
                    bd.Vacaciones.Add(vaca);
                    bd.SaveChanges();
                }
            }
            catch (EntityException e)
            {
                throw new EntityException(e.Message);
            }
        }


        public static List<Detalle_Vacaciones> EmpleadosVacaciones()
        {
            try
            {
                using (var bd = new RecursosHumanosEntities())
                {
                    var lst = from vac in bd.Vacaciones
                              join emp in bd.Empleados on vac.Id_Empleado equals emp.Id
                              select new Detalle_Vacaciones
                              {
                                  id = emp.Id,
                                  codigo = emp.Codigo,
                                  nombre = emp.Nombre,
                                  apellido = emp.Apellido,
                                  retrato = emp.Retrato,
                                  desde = vac.Desde.Value,
                                  hasta = vac.Hasta.Value,
                                  año = vac.Año_Correspondiente.Value,
                                  comentario = vac.Comentarios
                              };

                    return lst.ToList();
                }
            }
            catch (EntityException e)
            {
                throw new EntityException(e.Message);
            }
        }

        public static List<Empleados> DevolverEmpleadosActivos()
        {
            try
            {
                using (var bd = new RecursosHumanosEntities())
                {
                    var lst = bd.Empleados.Where(x => x.Estatus == "ACTIVO");
                    return lst.ToList();
                }
            }
            catch (EntityException e)
            {
                throw new EntityException(e.Message);
            }
        }

    }
}
