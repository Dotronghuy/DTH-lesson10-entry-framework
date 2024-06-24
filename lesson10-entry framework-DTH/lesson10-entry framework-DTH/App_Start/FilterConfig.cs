using System.Web;
using System.Web.Mvc;

namespace lesson10_entry_framework_DTH
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
