using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SubwayStopDistance.Models;

namespace SubwayStopDistance.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {           
            var md = new StopViewModel();

            return View(md);
        }

        [HttpPost]
        public ActionResult Index(StopViewModel sm)
        {
            if (ModelState.IsValid)
            {
                string[] From = sm.stop_latlonFrom.Split('_');
                string[] To = sm.stop_latlonTo.Split('_');
                double latF = Convert.ToDouble(From[0]);
                double lonF = Convert.ToDouble(From[1]);
                double latT = Convert.ToDouble(To[0]);
                double lonT = Convert.ToDouble(To[1]);
                ViewBag.distance = "The distance is " + DistanceAlgorithm.DistanceBetweenPlaces(lonF, latF, lonT, latT).ToString("0.00") + " Kilometres.";

                return View(sm);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
               
    }
}
