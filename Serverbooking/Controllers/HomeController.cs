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

namespace Serverbooking.Controllers
{
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(TestUser u)
        {
     
            if (ModelState.IsValid) 
            {
                using (ServerInfoEntities db = new ServerInfoEntities())
                {
                    var v = db.TestUsers.Where(a => a.Username.Equals(u.Username) && a.Password.Equals(u.Password)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LogedUserID"] = v.UserID.ToString();
                        Session["LogedUserFullname"] = v.FullName.ToString();
                        return RedirectToAction("AfterLogin");
                    }
                }
            }
            return View(u);
        }
        public ActionResult AfterLogin()
        {
            if (Session["LogedUserID"] != null)
            {
                return View("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}

    
    

