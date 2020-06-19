using System.Web;
using System.Web.Mvc;

namespace ADKZ_BugTrack
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
