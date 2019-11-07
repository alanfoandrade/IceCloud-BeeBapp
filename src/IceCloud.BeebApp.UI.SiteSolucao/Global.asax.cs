using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using IceCloud.BeebApp.Application.AutoMapper;

namespace IceCloud.BeebApp.UI.SiteSolucao
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();
        }
    }
}
