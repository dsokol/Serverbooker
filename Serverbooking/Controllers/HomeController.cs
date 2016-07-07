using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Serverbooking.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Content("Hello World!");
            //return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ServerInfo()
        {
            var serverinfo = new List<object>();
            serverinfo.Add(new { ServerID = "78078", Status = "Busy", ServerName = "TMR234", Environment = "RMS", ActiveBookingID = "Act234" });
            serverinfo.Add(new { ServerID = "24090", Status = "Free", ServerName = "TMR942", Environment = "TSM", ActiveBookingID = "Act942" });
            serverinfo.Add(new { ServerID = "25069", Status = "Busy", ServerName = "TMR165", Environment = "TRM", ActiveBookingID = "Act165" });
            return Json(serverinfo, JsonRequestBehavior.AllowGet);
        }
        
     }
  }
