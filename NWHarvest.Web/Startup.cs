using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NWHarvest.Web.Startup))]
namespace NWHarvest.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
