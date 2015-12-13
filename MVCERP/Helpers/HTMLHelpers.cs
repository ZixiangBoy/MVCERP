using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MVCERP {
    public static class HTMLHelper {
        public static string IsSelected(this HtmlHelper html, string controller = null, string action = null) {
            var cssClass = "active open";
            var currentAction = html.ViewContext.RouteData.Values["action"].ToString();
            var currentController = html.ViewContext.RouteData.Values["controller"].ToString();

            if (string.IsNullOrEmpty(controller))
                controller = currentController;

            if (string.IsNullOrEmpty(action))
                action = currentAction;

            return controller == currentController && action == currentAction ?
                cssClass : string.Empty;
        }

        public static string PageClass(this HtmlHelper html) {
            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            return currentAction;
        }

        public static HtmlString ShowPageNavigate(this HtmlHelper html, PetaPoco.Page<object> page) {
            var redirectTo = html.ViewContext.RequestContext.HttpContext.Request.Url.AbsolutePath;

            var pagelihtml = string.Format("<li class='{0}'><a href = '{1}?pageIndex={2}&pageSize={3}'>1</a></li> ");
            var pagehtml = new StringBuilder(@"<nav> < ul class='pagination'>");
            if (page.TotalPages > 1) {
                pagehtml.AppendFormat("<li class='active'><a href = '{0}?pageIndex=1&pageSize={1}'>1</a></li> ", redirectTo, page.ItemsPerPage);
                if (page.CurrentPage > 1) {//处理上一页的连接
                    pagehtml.AppendFormat("<a class='' href='{0}?pageIndex={1}&pageSize={2}'>上一页</a> ", redirectTo, page.CurrentPage - 1, page.ItemsPerPage);
                }

                pagehtml.Append(" ");
                int currint = 5;
                for (int i = 0; i <= 10; i++) {//一共最多显示10个页码，前面5个，后面5个
                    if ((page.CurrentPage + i - currint) >= 1 && (page.CurrentPage + i - currint) <= page.TotalPages) {
                        if (currint == i) {//当前页处理                           
                            pagehtml.AppendFormat("<a class='cpb' href='{0}?pageIndex={1}&pageSize={2}'>{3}</a> ", redirectTo, page.CurrentPage, page.ItemsPerPage, page.CurrentPage);
                        } else {//一般页处理
                            pagehtml.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>{3}</a> ", redirectTo, page.CurrentPage + i - currint, page.ItemsPerPage, page.CurrentPage + i - currint);
                        }
                    }
                    pagehtml.Append(" ");
                }
                if (page.CurrentPage < page.TotalPages) {//处理下一页的链接
                    pagehtml.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>下一页</a> ", redirectTo, page.CurrentPage + 1, page.ItemsPerPage);
                }

                pagehtml.Append(" ");
                if (page.CurrentPage != page.TotalPages) {
                    pagehtml.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>末页</a> ", redirectTo, page.TotalPages, page.ItemsPerPage);
                }
                pagehtml.Append(" ");
            }
            pagehtml.AppendFormat("<label>第{0}页 / 共{1}页</label>", page.CurrentPage, page.TotalPages);//这个统计加不加都行


            pagehtml.Append(" </ul></ nav > ");
            return new HtmlString(pagehtml.ToString());
        }
    }
}
