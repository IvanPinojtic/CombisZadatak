using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CombisApp.Startup))]
namespace CombisApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
