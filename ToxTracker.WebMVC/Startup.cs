using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ToxTracker.WebMVC.Startup))]
namespace ToxTracker.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
