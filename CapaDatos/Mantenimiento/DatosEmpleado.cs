using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Core;
using CapaEntidad;
using CapaEntidad.Vistas;
using System.Data.Entity.Infrastructure;

namespace CapaDatos
{
    public static class DatosEmpleado
    {
        public static Tuple<bool, string> InsertarEmpleado(Empleados emp)
        {
            try
            {
                using (var bd = new RecursosHumanosEntities())
                {
                    bd.Empleados.Add(emp);  
                    bd.SaveChanges();
                }

                return new Tuple<bool, string>
                (true, "Empleado Creado Con Exito !");
            }
            catch (DbUpdateException e)
            {
                return new Tuple<bool, string>
                (false, e.Message);
            }
        }


        public static Tuple<bool, string> ActualizarEmpleado(Empleados emp)
        {
            try
            {
                using (var bd = new RecursosHumanosEntities())
                {
                    var empleadoGuardado = bd.Empleados.Find(emp.Id);
                    empleadoGuardado.Codigo = emp.Codigo;
                    empleadoGuardado.Nombre = emp.Nombre;
                    empleadoGuardado.Apellido = emp.Apellido;
                    empleadoGuardado.Telefono = emp.Telefono;
                    empleadoGuardado.Departamento_Id = emp.Departamento_Id;
                    empleadoGuardado.Cargo_Id = emp.Cargo_Id;
                    empleadoGuardado.Estatus = emp.Estatus;
                    empleadoGuardado.Salario = emp.Salario;
                    bd.SaveChanges();
                }

                return new Tuple<bool, string>
                (true, "Empleado Actualizado Con Exito !");
            }
            catch (DbUpdateException e)
            {
                return new Tuple<bool, string>
                (false, e.Message);
            }
        }


        public static Tuple<bool, string> EliminarEmpleado(int id)
        {
            try
            {
                using (var bd = new RecursosHumanosEntities())
                {
                    bd.Empleados.Remove(bd.Empleados.Find(id));
                    bd.SaveChanges();
                }
                return new Tuple<bool, string>
                (true, "Empleado Eliminado Con Exito !");
            }
            catch (DbUpdateException e)
            {
                throw new Exception(e.InnerException.InnerException.Message);
            }
        }

        
        public static List<Detalle_Empleado> FiltroGeneral(string generico)
        {
            try
            {
                using (var bd = new RecursosHumanosEntities())
                {
                    var lst = from emp in bd.Empleados
                              join dpt in bd.Departamentos on emp.Departamento_Id equals dpt.Id
                              join carg in bd.Cargos on emp.Cargo_Id equals carg.Id where emp.Nombre== generico ||
                              emp.Apellido == generico || emp.Codigo == generico || emp.Nombre + " " + emp.Apellido ==generico ||
                              dpt.Nombre == generico                         
                              select new Detalle_Empleado
                              {
                                  id = emp.Id,
                                  codigo = emp.Codigo,
                                  nombre = emp.Nombre,
                                  apellido = emp.Apellido,
                                  telefono = emp.Telefono,
                                  cargo_n = carg.Nombre,
                                  cargo_id = carg.Id,
                                  departamento_n = dpt.Nombre,
                                  departamento_id = dpt.Id,
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
                throw new EntityException(e.Message);
            }
        }


        public static List<Detalle_Empleado> FiltroEstatus(string estatus)
        {
            try
            {
                using (var bd = new RecursosHumanosEntities())
                {
                    var lst = from emp in bd.Empleados
                              join dpt in bd.Departamentos on emp.Departamento_Id equals dpt.Id
                              join carg in bd.Cargos on emp.Cargo_Id equals carg.Id
                              where emp.Estatus.Equals(estatus)
                              select new Detalle_Empleado
                              {
                                  id = emp.Id,
                                  codigo = emp.Codigo,
                                  nombre = emp.Nombre,
                                  apellido = emp.Apellido,
                                  telefono = emp.Telefono,
                                  cargo_n = carg.Nombre,
                                  cargo_id = carg.Id,
                                  departamento_n = dpt.Nombre,
                                  departamento_id = dpt.Id,
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
                throw new EntityException(e.Message);

            }
        }
      
        public static List<Detalle_Empleado> TodosEmpleados()
        {
            try
            {
                using (var bd = new RecursosHumanosEntities())
                {
                    var lst = from emp in bd.Empleados
                              join dpt in bd.Departamentos on emp.Departamento_Id equals dpt.Id
                              join carg in bd.Cargos on emp.Cargo_Id equals carg.Id orderby dpt.Nombre descending
                              select new Detalle_Empleado
                              {
                                  id = emp.Id,
                                  codigo = emp.Codigo,
                                  nombre = emp.Nombre,
                                  apellido = emp.Apellido,
                                  telefono = emp.Telefono,
                                  cargo_n = carg.Nombre,
                                  cargo_id = carg.Id,
                                  departamento_n = dpt.Nombre,
                                  departamento_id = dpt.Id,
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
                throw new EntityException(e.Message);
            }
        }

    }

}
