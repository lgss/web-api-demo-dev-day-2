using System.Web;
using System.Web.Mvc;

namespace Web_API_Demo_Dev_Day
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
