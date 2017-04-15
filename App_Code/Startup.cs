using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(STORE.Startup))]
namespace STORE
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
