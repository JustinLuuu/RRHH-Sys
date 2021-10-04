using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaServicios.ServicioDepartamento
{
    public static class GenerarCodigoDepartamento
    {
        private static Random digitosRandom = new Random();

        public static void GenerarCodigo(Departamentos dpt_n)
        {
            int digitosAleatorios = digitosRandom.Next(10000, 99999);
            string[] separarCadena = dpt_n.Nombre.Split(' ');

            foreach(var pal in separarCadena)
            {
                dpt_n.Codigo += pal[0].ToString().ToUpper();
            }
            dpt_n.Codigo+=digitosAleatorios.ToString();
        }

    }
}
