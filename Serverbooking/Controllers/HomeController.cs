using Serverbooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Serverbooking.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Index";
            return Content("Hello World!");
            //return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Description page.";

            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Contact page.";

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

        public ActionResult Test()
        {
            return Content(@"{ ""records"":[ {""Name"":""Alfreds Futterkiste"",""City"":""Berlin"",""Country"":""Germany""}, {""Name"":""Ana Trujillo Emparedados y helados"",""City"":""México D.F."",""Country"":""Mexico""}, {""Name"":""Antonio Moreno Taquería"",""City"":""México D.F."",""Country"":""Mexico""}, {""Name"":""Around the Horn"",""City"":""London"",""Country"":""UK""}, {""Name"":""B's Beverages"",""City"":""London"",""Country"":""UK""}, {""Name"":""Berglunds snabbköp"",""City"":""Luleå"",""Country"":""Sweden""}, {""Name"":""Blauer See Delikatessen"",""City"":""Mannheim"",""Country"":""Germany""}, {""Name"":""Blondel père et fils"",""City"":""Strasbourg"",""Country"":""France""}, {""Name"":""Bólido Comidas preparadas"",""City"":""Madrid"",""Country"":""Spain""}, {""Name"":""Bon app'"",""City"":""Marseille"",""Country"":""France""}, {""Name"":""Bottom - Dollar Marketse"",""City"":""Tsawassen"",""Country"":""Canada""}, {""Name"":""Cactus Comidas para llevar"",""City"":""Buenos Aires"",""Country"":""Argentina""}, {""Name"":""Centro comercial Moctezuma"",""City"":""México D.F."",""Country"":""Mexico""}, {""Name"":""Chop - suey Chinese"",""City"":""Bern"",""Country"":""Switzerland""}, {""Name"":""Comércio Mineiro"",""City"":""São Paulo"",""Country"":""Brazil""} ] }");
        }
        public ActionResult Data()
        {
            var entities = new ServerInfoEntities();
            return View(entities.InfoServers.ToList());
        }
     }
  }
