using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaEntidad.Vistas_Detalles.Graficos;

namespace CapaDatos.Graficos
{
    public static class DatosGraficosDpt
    {
        public static List<DatosGraficoDept> DataGraphics()
        {
            using (var bd = new RecursosHumanosEntities())
            {
                var lst = from dpt in bd.Departamentos
                          join em in bd.Empleados on dpt.Id equals em.Departamento_Id into pila
                          orderby pila.Count(x => x.Departamento_Id == dpt.Id) descending
                          select new DatosGraficoDept
                          {
                            nombreDept = dpt.Nombre,
                            cantidadxDpt = pila.Count(x => x.Departamento_Id == dpt.Id)
                          };

                return lst.ToList();
            }
        }


    }
}
