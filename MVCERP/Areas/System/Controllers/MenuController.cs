using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCERP.Areas.System.Controllers
{
    public class MenuController : Controller
    {
        // GET: System/Menu
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Edit() {
            return View();
        }
    }
}