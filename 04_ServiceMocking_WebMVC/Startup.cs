using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_04_ServiceMocking_WebMVC.Startup))]
namespace _04_ServiceMocking_WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
