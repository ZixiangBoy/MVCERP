﻿using DbEntity;
using MVCERP.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetaPoco;

namespace MVCERP.Areas.System.Controllers
{
    public class UserController : DbController
    {
        // GET: System/User
        public ActionResult Index(int? pageIndex,int? pageSize,string username="")
        {
            //var users = Db.Fetch<t_user>(string.Empty);
            pageIndex = pageIndex ?? 1;
            pageSize = pageSize ?? 1;
            var whr = string.Empty;
            if (!string.IsNullOrEmpty(username)) {
                BuildWhr(ref whr, string.Format(" username = '{0}'",username));
            }

            var page = Db.Page<t_user>(pageIndex.Value, pageSize.Value, whr);


            if (Request.IsAjaxRequest())
            {
                return PartialView("_Users", page);
            }
            return View(page);
        }

        private void BuildWhr(ref string whr,string sql) {
            if (whr.Contains("where")) {
                whr += " and " + sql;
            } else {
                whr += " where " + sql;
            }
        }
    }
}