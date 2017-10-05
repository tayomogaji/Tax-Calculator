using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(taxCalculator.Startup))]
namespace taxCalculator
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
