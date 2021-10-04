using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Procesos;
using CapaEntidad;

namespace CapaNegocio.Procesos
{
    public static class NegocioNomina
    {
        public static bool NegociarCalculoNomina()
        {            
           return DatosNomina.CalcularNomina();
        }

        public static Nominas NegociarDevolverNomina()
        {
            return DatosNomina.DevolverNomina();
        }


    }
}
