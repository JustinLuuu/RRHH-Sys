using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Windows.Forms;     

namespace CapaDatos.Procesos
{
    public static class DatosNomina
    {       
        public static bool CalcularNomina()
        {
            try
            {
                TruncarTabla();
                using (var bd = new RecursosHumanosEntities())
                {                            
                    bd.Nominas.Add(new Nominas()
                    {
                    Fecha= DateTime.Today,
                    Monto_Total= (decimal)bd.Empleados.Where(x=> x.Estatus != "INACTIVO").Select(x=> x.Salario).Sum()
                    });
                    bd.SaveChanges();

                    return true;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return false;
            }
        }

        private static void TruncarTabla()
        {
            try
            {
                using (var bd = new RecursosHumanosEntities())
                {
                    bd.Nominas.RemoveRange(bd.Nominas);
                    bd.SaveChanges();                   
                }
            }
            catch(EntityException e )
            {
                throw new Exception(e.Message);
            }
        }

        public static Nominas DevolverNomina()
        {
            try
            {
                using (var bd = new RecursosHumanosEntities())
                {
                    var nomina = (from e in bd.Nominas select e).FirstOrDefault();
                    return nomina;
                }
            }
            catch (EntityException e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
