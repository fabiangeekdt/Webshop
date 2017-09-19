using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCWebshop.Startup))]
namespace MVCWebshop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
