using Hail_v2.App_Start;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hail_v2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            UnityBootstrap.Init();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
