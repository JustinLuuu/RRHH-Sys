using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad.Vistas_Detalles;
using CapaEntidad.Vistas;
using CapaEntidad;
using System.Windows.Forms;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

namespace CapaDatos.Procesos
{
    public static class Datos_Salida
    {
        public static Tuple<bool, string> DesactivarEmpleado(Salidas salida)
        {
            try
            {
                CambiarEstatus(salida.Id_Empleado, false);
                using (var bd = new RecursosHumanosEntities())
                {
                    salida.Fecha = DateTime.Today;
                    bd.Salidas.Add(salida);
                    bd.SaveChanges();                    
                }

                return new Tuple<bool, string>
               (true, "Empleado Desactivado Con Exito !");
            }
            catch (DbUpdateException e)
            {
                return new Tuple<bool, string>
                (false, e.Message);
            }
        }

        public static Tuple<bool, string> ActivarEmpleado(int idEmpleado)
        {
            try
            {
                CambiarEstatus(idEmpleado, true);
                using (var bd = new RecursosHumanosEntities())
                {
                    bd.Salidas.Remove(bd.Salidas.Find(idEmpleado));
                    bd.SaveChanges();
                }

                return new Tuple<bool, string>
                (true, "Empleado Activado Con Exito !");
            }
            catch (DbUpdateException e)
            {
                return new Tuple<bool, string>
                (false, e.Message);
            }
        }


        private static void CambiarEstatus(int id, bool indic)
        {
            using (var bd = new RecursosHumanosEntities())
            {
                var emp= bd.Empleados.Find(id).Estatus = (indic) ? "ACTIVO" : "INACTIVO";
                bd.SaveChanges();
            }
        }


        public static List<Detalle_Salida> DevolverEmpleados()
        {
            try
            {
                using (var bd = new RecursosHumanosEntities())
                {                                
                    var lst = from empl in bd.Empleados
                              join sal in bd.Salidas on empl.Id equals sal.Id_Empleado into joinedT
                              from sal in joinedT.DefaultIfEmpty()
                              select new Detalle_Salida
                              {                                 
                                  id = empl.Id,
                                  codigo = empl.Codigo,
                                  nombre = empl.Nombre,
                                  apellido = empl.Apellido,
                                  retrato = empl.Retrato,
                                  motivo = sal.Motivo,
                                  tipo = sal.Tipo,
                                  estatus = empl.Estatus,
                                  telefono= empl.Telefono
                              };
                                     
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
