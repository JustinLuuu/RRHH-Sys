using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaNegocio.Procesos;
using CapaEntidad;
using System.Windows.Forms;

namespace Presentacion.Controllers.Procesos
{
    public class SalidasController : Controller
    {
        [HttpGet]
        public ActionResult SalidasProceso(Salidas salida)
        {
            CargarRecursos();
            return View(salida);
        }

        [HttpPost]      
        public ActionResult AgregarSalida(Salidas salida)
        {
            if (ModelState.IsValid)
            {
                TempData["Notificacion"] = NegocioSalida.NegociarSalida(salida);
                return RedirectToAction("SalidasProceso");
            }

            TempData["ShowModalCreate"] = true;
            return RedirectToAction("SalidasProceso", salida);
        }

        [HttpPost]
        public ActionResult ActivarEmpleado(int idEmpleado)
        {
            TempData["Notificacion"] = NegocioSalida.NegociarActivar(idEmpleado);
            return RedirectToAction("SalidasProceso");
        }


        private void CargarRecursos()
        {
            ViewData["TablaEmpleadosActivos"] = NegocioSalida.NegociarDevolverEmpleados().Where(x=> x.estatus == "ACTIVO").ToList();
            ViewData["TablaEmpleadosInactivos"] = NegocioSalida.NegociarDevolverEmpleados().Where(x => x.estatus == "INACTIVO").ToList();
        }

    }
}