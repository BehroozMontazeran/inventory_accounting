using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UniProjectForms.Startup))]
namespace UniProjectForms
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
