using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Core;
using CapaEntidad;
using CapaEntidad.Vistas;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using CapaEntidad.Vistas_Detalles;

namespace CapaDatos
{
    public static class DatosCargo
    {
        public static Tuple<bool, string> InsertarCargo(Cargos cargo)
        {
            try
            {
                using (var bd = new RecursosHumanosEntities())
                {
                    bd.Cargos.Add(cargo);
                    bd.SaveChanges();

                    return new Tuple<bool, string>
                   (true, "Cargo Creado Con Exito !");
                }
            }
            catch (DbUpdateException e)
            {
                SqlException innerException = e.InnerException.InnerException as SqlException;

                return new Tuple<bool, string>
               (false, (innerException.Number == 2627 ?
                        "Ya existe un cargo con ese nombre !" : innerException.Message));
            }
        }


        public static Tuple<bool, string> EliminarCargo(int id)
        {
             using (var bd = new RecursosHumanosEntities())
             {
                try
                {
                    bd.Cargos.Remove(bd.Cargos.Find(id));
                    bd.SaveChanges();

                    return new Tuple<bool, string>
                           (true, "Cargo Eliminado Con Exito !");
                }
                catch (DbUpdateException e)
                {
                    SqlException innerException = e.InnerException.InnerException as SqlException;

                    return new Tuple<bool, string>
                   (false, (innerException.Number == 547 ?
                            $"Imposible eliminar el cargo de {bd.Cargos.Find(id).Nombre.ToUpper()} porque hay empleados que lo fungen !" 
                            : innerException.Message));
                }           
             }        
        }


        public static Tuple<bool, string> ActualizarCargo(Cargos cargo)
        {
            try
            {
                using (var bd = new RecursosHumanosEntities())
                {
                    var cargoGuardado = bd.Cargos.Find(cargo.Id);
                    cargoGuardado.Nombre = cargo.Nombre;
                    bd.SaveChanges();

                    return new Tuple<bool, string>
                           (true, "Cargo Actualizado Con Exito !");
                }

            }
            catch (DbUpdateException e)
            {
                SqlException innerException = e.InnerException.InnerException as SqlException;
                
                return new Tuple<bool, string>
               (false, (innerException.Number == 2627 ?
                        "Ya existe un cargo con ese nombre !" : innerException.Message));
            }
        }
      
        public static List<Detalle_Cargo> Listado()
        {
            try
            {
                using (var bd = new RecursosHumanosEntities())
                {
                    var lst = from carg in bd.Cargos
                              join em in bd.Empleados on carg.Id equals em.Cargo_Id into pila
                              orderby pila.Count(x => x.Cargo_Id == carg.Id) descending
                              select new Detalle_Cargo
                              {
                                  id = carg.Id,
                                  nombre = carg.Nombre,
                                  cantidad_empleados = pila.Count(x => x.Cargo_Id == carg.Id)
                              };

                    return lst.ToList();
                }
            }
            catch (EntityException e)
            {
                throw new Exception(e.Message);
            }
        }

        public static List<Detalle_Empleado> EmpleadosVinculados(string crgNombre)
        {
            try
            {
                using (var bd = new RecursosHumanosEntities())
                {
                    var lst = from emp in bd.Empleados
                              join dpt in bd.Departamentos on emp.Departamento_Id equals dpt.Id
                              join carg in bd.Cargos on emp.Cargo_Id equals carg.Id
                              where emp.Cargo_Id ==
                              (from crg in bd.Cargos where crg.Nombre == crgNombre select crg.Id).FirstOrDefault()
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
