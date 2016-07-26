using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Web.DynamicData;
using Serverbooking.Models;

namespace Serverbooking.Controllers
{
    public class ModifyController : Controller
    {
        // GET: Modify
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditingText()
        {
            var entities = new ServerInfoEntities();
            return View(entities.InfoServers.ToList());
        }
    }
}