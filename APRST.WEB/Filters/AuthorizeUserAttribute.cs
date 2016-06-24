using System.Web.Mvc;
using System.Web.Routing;

namespace APRST.WEB.Filters
{
    public class AuthorizeUserAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                    {"action", "Index"},
                    {"controller", "User"},
                });
        }

    }
}