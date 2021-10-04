using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc.Ajax;
using System.Web.Mvc;
using CapaNegocio;
using CapaEntidad;

namespace Presentacion.Controllers
{
    public class CargoController : Controller
    {

        [HttpGet]
        public ActionResult CargoProceso(Cargos cargos)
        {
            CargarRecursos();
            return View();
        }


        [HttpPost]
        public ActionResult AgregarCargo(Cargos cargo)
        {
            if (ModelState.IsValid)
            {
                TempData["Notificacion"] = NegocioCargo.NegociarInsercion(cargo);
                return RedirectToAction("CargoProceso");
            }

            TempData["ShowModalCreate"] = true;
            return RedirectToAction("CargoProceso", cargo);
        }


        [HttpPost]
        public ActionResult ActualizarCargo(Cargos cargo)
        {
            if (ModelState.IsValid)
            {
                TempData["Notificacion"] = NegocioCargo.NegociarActualizado(cargo);
                return RedirectToAction("CargoProceso");
            }

            TempData["ShowModalUpdate"] = true;
            return RedirectToAction("CargoProceso", cargo);
        }


        [HttpPost]
        public ActionResult EliminarCargo(Cargos cargo)
        {
            TempData["Notificacion"] = NegocioCargo.NegociarEliminado(cargo.Id);
            return RedirectToAction("CargoProceso");
        }

        [HttpGet]
        public ActionResult ResultadoBusquedaCarg(string nombreCrg)
        {
            ViewData["Resultados"] = NegocioCargo.NegociarEmpleadosVinculados(nombreCrg);
            ViewBag.NombreCrg = nombreCrg;
            return View();
        }

        private void CargarRecursos()
        {
            ViewData["TablaListadoCargos"] = NegocioCargo.NegociarListado();
            ViewData["CargosNombres"] = NegocioCargo.NegociarListado().Select(x => x.nombre).ToList();
        }

    }
}