using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BuildIt.Startup))]
namespace BuildIt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
