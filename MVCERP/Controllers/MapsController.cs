﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCERP.Controllers
{
    public class MapsController : Controller
    {
        // GET: Maps
        public ActionResult GoogleMaps()
        {
            return View();
        }
        public ActionResult VectorMaps()
        {
            return View();
        }
    }
}