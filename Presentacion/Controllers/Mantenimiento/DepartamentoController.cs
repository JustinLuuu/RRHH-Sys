using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaNegocio;
using CapaEntidad;
using System.Windows.Forms;

namespace Presentacion.Controllers
{
    public class DepartamentoController : Controller
    {

        [HttpGet]
        public ActionResult DepartamentoProceso(Departamentos dpt)
        {     
            CargarRecursos();       
            return View(dpt);
        }

        [HttpPost]
        public ActionResult AgregarDepartamento(Departamentos dpt)
        {
            if (ModelState.IsValid)
            {
                TempData["Notificacion"] = NegocioDepartamento.NegociarInsercion(dpt);
                return RedirectToAction("DepartamentoProceso");
            }

            TempData["ShowModalCreate"] = true;
            return RedirectToAction("DepartamentoProceso", dpt);
        }

        [HttpPost]
        public ActionResult ActualizarDepartamento(Departamentos dpt)
        {
            if (ModelState.IsValid)
            {
                TempData["Notificacion"] = NegocioDepartamento.NegociarActualizado(dpt);    
                return RedirectToAction("DepartamentoProceso");
            }
            else
            {
                TempData["ShowModalUpdate"] = true;
                return RedirectToAction("DepartamentoProceso", dpt);
            }
        }

        [HttpPost]
        public ActionResult EliminarDepartamento(Departamentos dpt)
        {            
           TempData["Notificacion"] = NegocioDepartamento.NegociarEliminado(dpt.Id);
           return RedirectToAction("DepartamentoProceso");              
        }

        [HttpGet]
        public ActionResult ResultadoBusquedaDpt(string nombreDpt)
        {
            ViewData["Resultados"] = NegocioDepartamento.NegociarEmpleadosVinculados(nombreDpt);
            ViewBag.NombreDpt = nombreDpt;
            return View();
        }

        private void CargarRecursos()
        {
            ViewData["TablaListadoDepartamentos"] = NegocioDepartamento.NegociarListado();
            ViewData["DepartamentosNombres"] = NegocioDepartamento.NegociarListado().Select(x => x.nombre).ToList();         
        }

    }
 
}