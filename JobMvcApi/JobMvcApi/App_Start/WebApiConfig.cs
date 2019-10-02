using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Serialization;

using JobMvcApi.Models.Repository;
using System.Web.Http.Cors;

namespace JobMvcApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            //Enable Cors
         //  config.EnableCors(new EnableCorsAttribute("http://localhost:4200", headers: "*", methods: "*"));


            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));



            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
