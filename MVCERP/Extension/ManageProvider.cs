using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Web;
using Web.Core.Class;
using Web.Core.Common;

namespace MVCERP {
    /// <summary>
    /// 管理提供者
    /// </summary>
    public class ManageProvider : IManageProvider
    {
        static MockSession session = new MockSession();

        #region 静态实例
        /// <summary>当前提供者</summary>
        public static IManageProvider Provider
        {
            get { return new ManageProvider(); }
        }
        #endregion

        /// <summary>
        /// 秘钥
        /// </summary>
        private string LoginUserKey = "LoginUserKey";
        /// <summary>
        /// 登陆提供者模式:Session、Cookie 
        /// </summary>
        private string LoginProvider = ConfigurationManager.AppSettings["LoginProvider"].ToString().Trim();
        /// <summary>
        /// 写入登录信息
        /// </summary>
        /// <param name="user">成员信息</param>
        public virtual void AddCurrent(IManageUser user)
        {
            try
            {
                if (LoginProvider == "Cookie")
                {
                    UltraCookie<IManageUser>.Index[LoginUserKey]=user;
                }
                else
                {
                    session[LoginUserKey]=user;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 当前用户
        /// </summary>
        /// <returns></returns>
        public virtual IManageUser Current()
        {
            try
            {
                IManageUser user = new IManageUser();
                if (LoginProvider == "Cookie")
                {
                    user= UltraCookie<IManageUser>.Index[LoginUserKey];
                }
                else
                {
                    user =(IManageUser)session[LoginUserKey];
                }
                if (user == null)
                {
                    throw new Exception("登录信息超时，请重新登录。");
                }
                return user;
            }
            catch
            {
                throw new Exception("登录信息超时，请重新登录。");
            }
        }
        /// <summary>
        /// 删除登录信息
        /// </summary>
        public virtual void EmptyCurrent()
        {
            if (LoginProvider == "Cookie")
            {
                HttpCookie objCookie = new HttpCookie(LoginUserKey);
                objCookie.Expires = DateTime.Now.AddYears(-5);
                HttpContext.Current.Response.Cookies.Add(objCookie);
            }
            else {
                HttpContext.Current.Session.Remove(LoginUserKey);
            }
        }
        /// <summary>
        /// 是否过期
        /// </summary>
        /// <returns></returns>
        public virtual bool IsOverdue()
        {
            object obj = null;
            if (LoginProvider == "Cookie")
            {
                obj = UltraCookie<IManageUser>.Index[LoginUserKey];
            }
            else
            {
                obj = session[LoginUserKey];
            }
            if (obj != null && obj.ToString() != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
