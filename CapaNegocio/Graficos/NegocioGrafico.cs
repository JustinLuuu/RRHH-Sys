using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad.Vistas_Detalles.Graficos;
using CapaDatos.Graficos;

namespace CapaNegocio.Graficos
{
    public static class NegocioGrafico
    {
        public static List<DatosGraficoDept> GraficoDepartamentos()
        {
            return DatosGraficosDpt.DataGraphics();
        }

    }
}
