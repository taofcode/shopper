using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shoppers.Startup))]
namespace Shoppers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
