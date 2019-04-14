using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Sigulda.WEB
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "AvengersApi-Amurs",
                routeTemplate: "api/avengers/amurs/{id}",
                defaults: new { controller = "Amurs", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
               name: "AvengersApi-Filiments",
               routeTemplate: "api/avengers/filiments/{id}",
               defaults: new { controller = "Filiments", id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
               name: "AvengersApi-Knaibles",
               routeTemplate: "api/avengers/knaibles/{id}",
               defaults: new { controller = "Knaibles", id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
               name: "AvengersApi-Materialis",
               routeTemplate: "api/avengers/materiali/{id}",
               defaults: new { controller = "Materialis", id = RouteParameter.Optional }
           );


            config.Routes.MapHttpRoute(
                name: "AvengersApi-Skruvjgrieznis",
                routeTemplate: "api/avengers/skruvjgrieznis/{id}",
                defaults: new { controller = "Skruvjgrieznis", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "AvengersApi-Viles",
                routeTemplate: "api/avengers/viles/{id}",
                defaults: new { controller = "Viles", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "BatmanApi-AktivaKomponentes",
                routeTemplate: "api/batman/aktiva-komponente/{id}",
                defaults: new { controller = "AktivaKomponentes", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
               name: "BatmanApi-Akumulators",
               routeTemplate: "api/batman/akumulators/{id}",
               defaults: new { controller = "Akumulators", id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
                name: "BatmanApi-Baterija",
                routeTemplate: "api/batman/baterija/{id}",
                defaults: new { controller = "Baterijas", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "BatmanApi-ElektromehaniskaKomponente",
                routeTemplate: "api/batman/elektromehaniska-komponente/{id}",
                defaults: new { controller = "ElektromehaniskaKomponentes", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "BatmanApi-EnergijasKomponente",
                routeTemplate: "api/batman/energijas-komponente/{id}",
                defaults: new { controller = "EnergijasKomponentes", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "BatmanApi-GatavaShemaModulis",
                routeTemplate: "api/batman/gatava-shema-modulis/{id}",
                defaults: new { controller = "GatavaShemaModulis", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "BatmanApi-Komponente",
                routeTemplate: "api/batman/komponente/{id}",
                defaults: new { controller = "Komponente", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "BatmanApi-Komponentes",
                routeTemplate: "api/batman/komponentes/{id}",
                defaults: new { controller = "Komponentes", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "BatmanApi-Sensors",
                routeTemplate: "api/batman/sensors/{id}",
                defaults: new { controller = "Sensors", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "BatmanApi-PasivaKomponente",
                routeTemplate: "api/batman/pasiva-komponente/{id}",
                defaults: new { controller = "PasivaKomponentes", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "BatmanApi-VadisController",
                routeTemplate: "api/batman/vadi/{id}",
                defaults: new { controller = "VadisController", id = RouteParameter.Optional }
            );
        }
    }
}
