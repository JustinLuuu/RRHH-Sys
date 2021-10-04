using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CapaEntidad;
using CapaEntidad.Vistas;
using CapaNegocio;
using System.Windows.Forms;

namespace Presentacion.Controllers
{
    public class EmpleadoController : Controller
    {
        [HttpGet]
        public ActionResult EmpleadoProceso(Empleados emp)
        {
            CargarRecursos();
            return View(emp);
        }

        [HttpPost]
        public ActionResult AgregarEmpleado(Empleados empleado)
        {
            if (ModelState.IsValid)
            {
                TempData["Notificacion"] = NegocioEmpleado.NegociarInsercion(empleado);
                return RedirectToAction("EmpleadoProceso");
            }

            TempData["ShowModalCreate"] = true;
            return RedirectToAction("EmpleadoProceso", empleado);
        }

       
        [HttpPost]
        public ActionResult ActualizarEmpleado(Empleados empleado)
        {
            if (ModelState.IsValid)
            {
                TempData["Notificacion"] = NegocioEmpleado.NegociarActualizado(empleado);               
                return RedirectToAction("EmpleadoProceso");
            }
            
            TempData["ShowModalUpdate"] = true;
            return RedirectToAction("EmpleadoProceso", empleado);            
        }

        [HttpPost]
        public ActionResult EliminarEmpleado(Empleados empleado)
        {
            TempData["Notificacion"] = NegocioEmpleado.NegociarEliminado(empleado.Id);           
            return RedirectToAction("EmpleadoProceso");
        }

        [HttpGet]   
        public ActionResult ResultadoBusquedaEmp(string generico)
        {
            CargarRecursos();
       
            (var listado, var tituloResultado) = NegocioEmpleado.NegociarFiltro(generico);        
            ViewData["Resultados"] = (listado.Any()) ? listado : null;
            ViewBag.TituloResultado = tituloResultado;
            return View();
        }
     
        private void CargarRecursos()
        {
            ViewData["ListadoEmpleados"] = RecursosVistaEmp.ListadoEmpleadosTabla();
            ViewData["DropDownListDepartamentosInsert"] = RecursosVistaEmp.DropDownListDepartamentosWithValueText();
            ViewData["DropDownListDepartamentosFind"] = RecursosVistaEmp.DropDownListDepartamentosJustText();
            ViewData["dropdownListCargos"] = RecursosVistaEmp.DropDownListCargos();
        }

    }


    public static class RecursosVistaEmp
    {           
        public static List<Detalle_Empleado> ListadoEmpleadosTabla()
        {
           return NegocioEmpleado.NegociarListado();
        }

        public static List<SelectListItem> DropDownListCargos()
        {
            var dropdownListCargos = NegocioCargo.NegociarListado().ConvertAll(d =>
             new SelectListItem()
             {
                 Text = d.nombre.ToString(),
                 Value = d.id.ToString(),
                 Selected = false
             });

            return dropdownListCargos;
        }

        public static List<SelectListItem> DropDownListDepartamentosWithValueText()
        {
            var dropdownListDepartamentos= NegocioDepartamento.NegociarListado().ConvertAll(d =>
             new SelectListItem()
             {
                 Text = d.nombre.ToString(),
                 Value = d.id.ToString(),
                 Selected = false
             });

            return dropdownListDepartamentos;
        }

        public static List<SelectListItem> DropDownListDepartamentosJustText()
        {
            var dropdownListDepartamentos = NegocioDepartamento.NegociarListado().ConvertAll(d =>
              new SelectListItem()
              {
                  Text = d.nombre.ToString(),
                  Value = d.nombre.ToString(),
                  Selected = false
              });

            return dropdownListDepartamentos;
        }

    }
}