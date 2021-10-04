using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaEntidad.Vistas_Detalles;

namespace CapaDatos.Procesos
{
    public class DatosPermisos
    {
        public static void DarPermiso(Permisos permiso)
        {

            try
            {
                using (var bd = new RecursosHumanosEntities())
                {
                    bd.Permisos.Add(permiso);
                    bd.SaveChanges();
                }
            }
            catch (EntityException e)
            {
                throw new EntityException(e.Message);
            }
        }

        public static List<Detalle_Permisos> EmpleadosVacaciones()
        {
            try
            {
                using (var bd = new RecursosHumanosEntities())
                {
                    var lst = from per in bd.Permisos
                              join emp in bd.Empleados on per.Id_Empleado equals emp.Id
                              select new Detalle_Permisos
                              {
                                  codigo = emp.Codigo,
                                  nombre = emp.Nombre,
                                  apellido = emp.Apellido,
                                  retrato = emp.Retrato,
                                  desde = per.Desde.Value,
                                  hasta = per.Hasta.Value,
                                  comentario = per.Comentarios
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
