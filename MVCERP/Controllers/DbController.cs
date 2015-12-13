using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCERP.Controllers
{
    public class DbController : Controller
    {

        private string _connString;
        /// <summary>
        /// 连接字符串
        /// </summary>
        public virtual string ConnString {
            get {
                return string.IsNullOrEmpty(_connString) ? System.Configuration.ConfigurationManager.ConnectionStrings["dbconstr"].ConnectionString : _connString;
            }
        }


        private Database _db;
        /// <summary>
        /// 连接字符串
        /// </summary>
        public virtual Database Db {
            get {
                return _db ?? new Database(this.ConnString);
            }
        }

        public DbController() {
            this._connString = System.Configuration.ConfigurationManager.ConnectionStrings["dbconstr"].ConnectionString;
        }
    }
}