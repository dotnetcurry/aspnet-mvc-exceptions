using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5_Exceptions.Startup))]
namespace MVC5_Exceptions
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
