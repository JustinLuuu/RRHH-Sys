using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaNegocio.Graficos;
using Newtonsoft.Json;
using System.Windows.Forms;
using CapaEntidad.Vistas_Detalles.Graficos;

namespace Presentacion.Controllers.Mantenimiento
{
    public class GraficoController : Controller
    {
        // GET: Grafico
        public ActionResult GraficoMostrar()
        {            
            ViewBag.DataPoints = JsonConvert.SerializeObject(NegocioGrafico.GraficoDepartamentos());
			return View();
		}
    }
}