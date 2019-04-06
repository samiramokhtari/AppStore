using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppStore.UI.Startup))]
namespace AppStore.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
