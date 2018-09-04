using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomerApplication.Startup))]
namespace CustomerApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
