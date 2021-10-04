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
   public class DatosLicencia
    {
        public static void DarLicencia(Licencias licencia)
        {
            try
            {
                using (var bd = new RecursosHumanosEntities())
                {                    
                    bd.Licencias.Add(licencia);
                    bd.SaveChanges();
                }
            }
            catch (EntityException e)
            {
                throw new EntityException(e.Message);
            }
        }

        public static List<Detalle_Licencia> EmpleadosLicencia()
        {
            try
            {
                using (var bd = new RecursosHumanosEntities())
                {
                    var lst = from lic in bd.Licencias
                              join emp in bd.Empleados on lic.Id_Empleado equals emp.Id
                              select new Detalle_Licencia
                              {
                                  codigo = emp.Codigo,
                                  nombre = emp.Nombre,
                                  apellido = emp.Apellido,
                                  retrato = emp.Retrato,
                                  desde = lic.Desde.Value,
                                  hasta = lic.Hasta.Value,
                                  motivo = lic.Motivo,
                                  comentario = lic.Comentarios
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
