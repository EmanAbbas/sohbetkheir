using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gam3iaWeb.Startup))]
namespace Gam3iaWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
