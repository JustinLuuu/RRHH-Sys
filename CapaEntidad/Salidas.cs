//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaEntidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Salidas
    {
        public int Id { get; set; }
        public int Id_Empleado { get; set; }

        [Required(ErrorMessage = "Debe elegir un tipo de salida !")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "Debe tener un motivo !")]
        public string Motivo { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
    
        public virtual Empleados Empleados { get; set; }
    }
}