using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TASK007.Models;
using TASK007.Repository;

namespace TASK007.Controllers
{
    // CRMConnection connection

        public class HomeController : Controller
        {
            [AllowAnonymous]
            public ActionResult Index()
            {
                return View();
            }

            [AllowAnonymous]
            public ActionResult About()
            {
                return View();
            }

            [AllowAnonymous]
            public ActionResult Contact()
            {
                ViewBag.Message = "Your contact page.";

                return View();
            }
        }
    }