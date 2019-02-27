using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Enabling CORS
            // CORS is a W3C standard that allows you to get away from the same origin policy adopted by the browsers
            // to restrict access from one domain to resources belonging to another domain. 
            var corsAttr = new EnableCorsAttribute("*" // Origin Url here 
                , "*"
                , "*");
            config.EnableCors(corsAttr);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
             
            // Change default WebAPI to JSON formatter
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

            // Return JSON with camelCased property names on objects and all sub-objects 
            // (In our case there is only one property - id)
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
