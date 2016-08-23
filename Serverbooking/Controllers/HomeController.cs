using Serverbooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.DynamicData;
using System.Data.Entity;
using System.Net;
using LoginFormApp.Models;

namespace Serverbooking.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }


        }

    }
}

    
    

