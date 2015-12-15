using DbEntity;
using MVCERP.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCERP.Areas.System.Controllers
{
    public class RoleController : DbController
    {
        // GET: System/Role
        public ActionResult Index(int? pageIndex, int? pageSize,string rolename="")
        {
            pageIndex = pageIndex ?? 1;
            pageSize = pageSize ?? 1;
            var whr = string.Empty;
            if (!string.IsNullOrEmpty(rolename))
            {
                BuildWhr(ref whr, string.Format(" username = '{0}'", rolename));
            }

            var page = Db.Page<t_role>(pageIndex.Value, pageSize.Value, whr);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Roles", page);
            }
            return View(page);
        }

        private void BuildWhr(ref string whr, string sql)
        {
            if (whr.Contains("where"))
            {
                whr += " and " + sql;
            }
            else {
                whr += " where " + sql;
            }
        }
    }
}