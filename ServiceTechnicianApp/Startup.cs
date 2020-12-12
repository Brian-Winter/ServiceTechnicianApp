using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ServiceTechnicianApp.Startup))]
namespace ServiceTechnicianApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
