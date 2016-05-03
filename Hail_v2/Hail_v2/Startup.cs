using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hail_v2.Startup))]
namespace Hail_v2
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}