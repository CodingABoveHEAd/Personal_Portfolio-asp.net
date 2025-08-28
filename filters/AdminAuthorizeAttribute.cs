using System.Web;
using System.Web.Mvc;

namespace Personal_Portfolio2.Filters
{
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return (httpContext.Session != null) && (httpContext.Session["IsAdmin"] as bool? == true);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/Account/Login");
        }
    }
}
