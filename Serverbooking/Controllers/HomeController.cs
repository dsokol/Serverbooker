﻿using Serverbooking.Models;
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

        public ActionResult Data()
        {
            var entities = new ServerInfoEntities();
            return View(entities.InfoServers.ToList());
        }
        public ActionResult BookingData()
        {
            var entities = new ServerInfoEntities();
            return View(entities.BookingInfo.ToList());
        }
     }
  }
