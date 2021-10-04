using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CapaEntidad.Vistas_Detalles.Graficos
{
    [DataContract]
    public class DatosGraficoDept
    {
      
        [DataMember(Name = "label")]
        public string nombreDept = "";

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "y")]
        public int cantidadxDpt ;
    }
}
