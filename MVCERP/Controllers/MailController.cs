﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCERP.Controllers
{
    public class MailController : Controller
    {
        // GET: Mail
        public ActionResult Inbox()
        {
            return View();
        }
        public ActionResult ComposeMail()
        {
            return View();
        }
    }
}