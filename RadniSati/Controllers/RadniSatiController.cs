using RadniSati.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RadniSati.Controllers
{
    public class RadniSatiController : Controller
    {
        // GET: RadniSati
        public ViewResult UnosSati()
        {
            return View();
        }

       

        public ActionResult IspisSati(FormCollection form)
        {
            
            ViewBag.ulazak = form["Ulazak"];
            ViewBag.izlazak = form["Izlazak"];
            DateTime date1 = DateTime.ParseExact(ViewBag.ulazak, "dd'.'MM'.'yyyy - HH:mm:ss", null);
            //Debug.WriteLine(date1);
            DateTime date2 = DateTime.ParseExact(ViewBag.izlazak, "dd'.'MM'.'yyyy - HH:mm:ss", null);
            //Debug.WriteLine(date2);
            TimeSpan interval = date2 - date1;
            ViewBag.interval = interval;
            //Debug.WriteLine(interval);
            TimeSpan span = new TimeSpan(08, 00, 00);
            TimeSpan visak = interval - span;
            ViewBag.visak = visak;
            //Debug.WriteLine(visak);

            return View();
        }
    }
}