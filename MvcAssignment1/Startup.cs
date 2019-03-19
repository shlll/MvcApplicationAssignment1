using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcAssignment1.Startup))]
namespace MvcAssignment1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
