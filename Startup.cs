using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppletSoftware.Startup))]
namespace AppletSoftware
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
