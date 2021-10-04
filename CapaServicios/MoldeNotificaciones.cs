using System;


namespace CapaServicios
{
    public static class MoldeNotificaciones
    {
        public static string DevolverNotificacion(Tuple<bool, string > tuple)
        {            
            return string.Format
            (
              "<script>" +  
              $"swal(\"{tuple.Item2}\", \"{(tuple.Item1 ? "Afortunadamente" : "Algo salio mal")}\", \"{(tuple.Item1 ? "success" : "warning")}\")  " +
              "</script>"
            );
        }
    }
}
