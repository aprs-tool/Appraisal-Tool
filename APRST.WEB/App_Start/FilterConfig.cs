using System.Web.Mvc;
using APRST.WEB.Filters;

namespace APRST.WEB
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeUserAttribute());
        }
    }
}
