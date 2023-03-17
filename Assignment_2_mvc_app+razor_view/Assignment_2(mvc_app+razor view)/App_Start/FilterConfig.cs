using System.Web;
using System.Web.Mvc;

namespace Assignment_2_mvc_app_razor_view_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
