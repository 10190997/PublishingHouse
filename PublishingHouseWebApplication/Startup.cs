using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PublishingHouseWebApplication.Startup))]
namespace PublishingHouseWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
