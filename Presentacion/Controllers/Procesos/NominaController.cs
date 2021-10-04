using System.Web.Mvc;
using CapaNegocio.Procesos;

namespace Presentacion.Controllers.Procesos
{
    public class NominaController : Controller
    {
        [HttpGet]
        public ActionResult NominaProceso()
        {
            return View(NegocioNomina.NegociarDevolverNomina());
        }

        [HttpPost]
        public ActionResult NominaProceso(bool ex= true)
        {
            TempData["CalculoExito"] = NegocioNomina.NegociarCalculoNomina();
            return View(NegocioNomina.NegociarDevolverNomina());
        }


    }
}