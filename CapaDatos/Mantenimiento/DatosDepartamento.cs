using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Core;
using CapaEntidad;
using CapaEntidad.Vistas_Detalles;
using CapaEntidad.Vistas;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;


namespace CapaDatos
{
    public static class DatosDepartamento
    {
        public static Tuple<bool, string> InsertarDept(Departamentos dpt)
        {
            try
            {
                using (var bd = new RecursosHumanosEntities())
                {
                    bd.Departamentos.Add(dpt);
                    bd.SaveChanges();

                    return new Tuple<bool, string>
                   (true, "Departamento Creado Con Exito !");
                }
            }
            catch (DbUpdateException e)
            {
                SqlException innerException = e.InnerException.InnerException as SqlException;

                return new Tuple<bool, string>
               (false, (innerException.Number == 2627 ?
                        "Ya existe un departamento con ese nombre !" : innerException.Message));
            }
        }

        public static Tuple<bool, string> ActualizarDpt(Departamentos dpt)
        {
            try
            {
                using (var bd = new RecursosHumanosEntities())
                {
                    var dptGuardado = bd.Departamentos.Find(dpt.Id);
                    dptGuardado.Nombre = dpt.Nombre;
                    bd.SaveChanges();

                    return new Tuple<bool, string>
                   (true, "Departamento Actualizado Con Exito !");
                }
            }
            catch (DbUpdateException  e)
            {
                SqlException innerException = e.InnerException.InnerException as SqlException;

                return new Tuple<bool, string>
               (false, (innerException.Number == 2627 ?
                        "Ya existe un departamento con ese nombre !" : innerException.Message));
            }
        }


        public static Tuple<bool, string> EliminarDpt(int id)
        {            
           using (var bd = new RecursosHumanosEntities())
           {
                try
                {
                    bd.Departamentos.Remove(bd.Departamentos.Find(id));
                    bd.SaveChanges();

                    return new Tuple<bool, string>
                   (true, "Departamento Eliminado Con Exito !");
                }
                catch (DbUpdateException e)
                {
                    SqlException innerException = e.InnerException.InnerException as SqlException;

                    return new Tuple<bool, string>
                    (false, (innerException.Number == 547 ?
                             $"Imposible eliminar el Departamento de {bd.Departamentos.Find(id).Nombre.ToUpper()} porque hay empleados que pertenecen al mismo"
                             : innerException.Message));
                }
            }
                      
        }
     
        public static List<Detalle_Departamento> Listado()
        {
            try
            {
                using (var bd = new RecursosHumanosEntities())
                {
                    var lst = from dpt in bd.Departamentos  
                              join em in bd.Empleados on dpt.Id equals em.Departamento_Id into pila
                              orderby pila.Count(x=> x.Departamento_Id == dpt.Id) descending
                              select new Detalle_Departamento
                              {
                                  id = dpt.Id,
                                  codigo = dpt.Codigo,
                                  nombre = dpt.Nombre,
                                  cantidad_empleados = pila.Count(x => x.Departamento_Id == dpt.Id)
                              };

                    return lst.ToList();
                }
            }
            catch (EntityException e)
            {
                throw new Exception(e.Message);
            }
        }
          
        public static List<Detalle_Empleado> EmpleadosVinculados(string dptNombre)
        {
            try
            {
                using (var bd = new RecursosHumanosEntities())
                {
                    var lst = from emp in bd.Empleados
                              join dpt in bd.Departamentos on emp.Departamento_Id equals dpt.Id
                              join carg in bd.Cargos on emp.Cargo_Id equals carg.Id
                              where emp.Departamento_Id ==
                              (from p in bd.Departamentos where p.Nombre == dptNombre select p.Id).FirstOrDefault()
                              orderby emp.Nombre
                              select new Detalle_Empleado
                              {
                                  codigo = emp.Codigo,
                                  nombre = emp.Nombre,  
                                  apellido = emp.Apellido,
                                  telefono = emp.Telefono,
                                  cargo_n = carg.Nombre,
                                  departamento_n = dpt.Nombre,
                                  estatus = emp.Estatus,
                                  retrato = emp.Retrato,
                                  salario = emp.Salario.Value,
                                  fecha_ingreso = emp.Fecha_Ingreso.Value
                              };

                    return lst.ToList();
                }
            }
            catch (EntityException e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}
