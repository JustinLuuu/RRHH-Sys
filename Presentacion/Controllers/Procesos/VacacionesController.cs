using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio.Procesos;

namespace Presentacion.Controllers.Procesos
{
    public class VacacionesController : Controller
    {
        [HttpGet]
        public ActionResult VacacionesProceso()
        {
            CargarRecursos();
            return View();
        }

        [HttpPost]
        public ActionResult VacacionesProceso(Vacaciones vaca)
        {
            CargarRecursos();

            if (ModelState.IsValid)
            {
                NegocioVacaciones.NegociarVacaciones(vaca);
                return RedirectToAction("VacacionesProceso");
            }

            ViewBag.ModalInsertError = true;
            return View(vaca);

        }

        private void CargarRecursos()
        {
            ViewData["TablaListadoEmpleadosConVacaciones"] = NegocioVacaciones.NegociarEmpleadosConVacaciones();
            ViewData["TablaListadoEmpleados"] = NegocioVacaciones.NegociarTodosEmpleados();
        }

    }
}