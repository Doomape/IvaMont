﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IvaMont.Controllers
{
    public class SiteController : Controller
    {
        //
        // GET: /Site/

        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Products()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }
        public ActionResult Clients()
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
