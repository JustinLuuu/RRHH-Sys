using System;
using CapaEntidad;

namespace CapaServicios.ServicioEmpleado
{
    public static class ObtenerFoto
    {
        private static int rango;
        
        public static void SetearFoto(ref Empleados emp)
        {
            var instanciaUnica = NumeroAleatorio.GetInstance();
            rango = instanciaUnica.aleatorioNum.Next(1, 99);

            emp.Retrato = (emp.Sexo == "masculino") ?
            string.Format("https://randomuser.me/api/portraits/med/men/{0}.jpg", rango) : 
            string.Format("https://randomuser.me/api/portraits/med/women/{0}.jpg", rango);
        }

    }

    public class NumeroAleatorio
    {
        public Random aleatorioNum { get; } = new Random();

        private static NumeroAleatorio instancia;
        private NumeroAleatorio() { }
      
        public static NumeroAleatorio GetInstance()
        {            
            return (instancia is null) ? instancia = new NumeroAleatorio() : instancia;
        }

    }

}
