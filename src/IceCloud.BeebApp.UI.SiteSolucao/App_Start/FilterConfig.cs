using System.Web.Mvc;
using IceCloud.BeebApp.Infra.CrossCutting.Filters;

namespace IceCloud.BeebApp.UI.SiteSolucao
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalActionLogger());
        }
    }
}
