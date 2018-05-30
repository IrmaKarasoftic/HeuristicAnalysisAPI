using System.Web.Mvc;
using System.Web.Http;
namespace HeuristicAnalysis.API
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
