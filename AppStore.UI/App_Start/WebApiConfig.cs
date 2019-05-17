using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace AppStore.UI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "fullAddress",
                routeTemplate: "api/{controller}/{action}/{id}",
                constraints: new { id = @"\d{1,10}", action = @"[a-zA-Z].*" },
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "fullWithStringAddress",
                routeTemplate: "api/{controller}/{action}/{value}",
                constraints: new { value = @"[a-zA-Z0-9]+", action = @"[a-zA-Z].*" },
                defaults: new { value = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional, action = "Get" }
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            //config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
        }
    }
}
