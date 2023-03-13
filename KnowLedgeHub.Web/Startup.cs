using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KnowLedgeHub.Web.Startup))]
namespace KnowLedgeHub.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
