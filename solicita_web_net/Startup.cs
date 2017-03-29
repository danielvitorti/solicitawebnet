using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(solicita_web_net.Startup))]
namespace solicita_web_net
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
