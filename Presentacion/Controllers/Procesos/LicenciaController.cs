using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio.Procesos;

namespace Presentacion.Controllers.Procesos
{
    public class LicenciaController : Controller
    {
       [HttpGet]
        public ActionResult LicenciaProceso()
        {
            CargarRecursos();
            return View();
        }

        [HttpPost]
        public ActionResult LicenciaProceso(Licencias licencia)
        {
            CargarRecursos();

            if (ModelState.IsValid)
            {
                NegocioLicencia.NegociarLicencia(licencia);
                return RedirectToAction("LicenciaProceso");
            }

            ViewBag.ModalInsertError = true;
            return View(licencia);
        }

        private void CargarRecursos()
        {
            ViewData["ListadoTablaEmpleadosLicencia"] = NegocioLicencia.NegociarEmpleadosLicencia();
            ViewData["ListadoTablaEmpleados"] = NegocioLicencia.NegociarEmpleados();
        }


    }
}