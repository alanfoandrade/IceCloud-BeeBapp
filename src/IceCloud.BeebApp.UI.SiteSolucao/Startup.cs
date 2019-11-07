using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IceCloud.BeebApp.UI.SiteSolucao.Startup))]
namespace IceCloud.BeebApp.UI.SiteSolucao
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
