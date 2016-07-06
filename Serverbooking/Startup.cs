using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Serverbooking.Startup))]
namespace Serverbooking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
