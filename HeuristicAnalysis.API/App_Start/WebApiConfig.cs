using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json.Serialization;

namespace HeuristicAnalysis.API
{
    internal class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            // Web API configuration and services
            configuration.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            // Web API routes
            configuration.MapHttpAttributeRoutes();

            configuration.Routes.MapHttpRoute("API Default", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
        }
    }
}