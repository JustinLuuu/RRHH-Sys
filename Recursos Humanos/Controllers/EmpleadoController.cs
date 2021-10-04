using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;
using CapaEntidad.Enums;

namespace Recursos_Humanos.Controllers
{
    public class EmpleadoController : Controller
    {
        [HttpGet]
        public ActionResult EmpleadoProceso()
        {
            ListadoEmpleados();
            ListadoDepartamentos();
            return View();
        }

        [HttpPost]
        public ActionResult EmpleadoProceso(Empleados empleado, VerEnum operacion)
        {
            ListadoEmpleados();
            ListadoDepartamentos();

            switch (operacion)
            {
                case VerEnum.INSERT:

                    if (ModelState.IsValid)
                    {
                        ViewBag.ModalInsertError = false;
                        TempData["successInsert"] = true;
                        NegocioEmpleado.NegociarInsercion(empleado);
                    }
                    else
                    {
                        ViewBag.ModalInsertError = true;
                        return View(empleado);
                    }

                    break;

                case VerEnum.UPDATE:

                    if (ModelState.IsValid)
                    {
                        ViewBag.ModalUpdateError = false;
                        TempData["successUpdate"] = true;
                        NegocioEmpleado.NegociarActualizado(empleado);
                    }
                    else
                    {
                        ViewBag.ModalUpdateError = true;
                        return View(empleado);
                    }
                    break;

                case VerEnum.DELETE:
                    TempData["successDelete"] = true;
                    NegocioEmpleado.NegociarEliminado(empleado.Id);
                    break;

                default:
                    throw new Exception();

            }
            return RedirectToAction("EmpleadoProceso");
        }

        public ActionResult ResultadoBusquedaEmp(string generico)  // generar vista !
        {
            ListadoDepartamentos();

            var listado = NegocioEmpleado.NegociarBusquedaGenerica(generico);
            ViewData["Resultados"] = (listado.Any()) ? listado : null;
            return View();
        }


        private void ListadoEmpleados()
        {
            ViewData["ListadoEmpleados"] = NegocioEmpleado.NegociarListado();
        }

        private void ListadoDepartamentos()
        {
            var lstDpt = NegocioEmpleado.NegociarListado();

            ViewData["ListadoDepartamentos"] = lstDpt.ConvertAll(d =>
             new SelectListItem()
             {
                 Text = d.nombre.ToString(),
                 Value = d.departamento_id.ToString(),
                 Selected = false
             });
        }

    }
}