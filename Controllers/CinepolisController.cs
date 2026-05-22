using IDGS904ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IDGS904ASP.Controllers
{
    public class CinepolisController : Controller
    {
        // GET: Cinepolis
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Cinepolis cine)
        {
            double total = 0;
            double precioBoleto = 12.000; 

            
            if (cine.CantidadBoletos > (cine.CantidadCompradores * 7))
            {
                ViewBag.Error = "No pueden comprar mas de 7 boletos por cabezaa";
                return View();
            }

            total = cine.CantidadBoletos * precioBoleto;

            
            if (cine.CantidadBoletos > 5)
            {
                total = total - (total * 0.15);
            }
            else if (cine.CantidadBoletos >= 3)
            {
                total = total - (total * 0.10);
            }

            
            if (cine.Tarjeta == true)
            {
                total = total - (total * 0.10);
            }

            ViewBag.Nombre = cine.Nombre;
            ViewBag.Total = total;

            return View();
        }
    }
}