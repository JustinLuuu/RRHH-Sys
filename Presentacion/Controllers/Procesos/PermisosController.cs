using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaNegocio.Procesos;
using CapaEntidad;

namespace Presentacion.Controllers.Procesos
{
    public class PermisosController : Controller
    {
        [HttpGet]
        public ActionResult PermisosProceso()
        {
            CargarRecursos();
            return View();
        }

        public ActionResult PermisosProceso(Permisos permiso)
        {
            CargarRecursos();

            if (ModelState.IsValid)
            {
                NegocioPermisos.NegociarPermiso(permiso);
                return RedirectToAction("PermisosProceso");
            }

            ViewBag.ModalInsertError = true;
            return View(permiso);
        }

        private void CargarRecursos()
        {
            ViewData["ListadoTablaEmpleadosPermiso"] = NegocioPermisos.NegociarEmpleadosPermiso();
            ViewData["ListadoTablaEmpleados"] = NegocioPermisos.NegociarEmpleados(); 

        }
    }
}