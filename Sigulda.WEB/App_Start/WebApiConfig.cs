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
                name: "AvengersApi-Iekartas",
                routeTemplate: "api/avengers/iekarta/{id}",
                defaults: new { controller = "Iekartas", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "AvengersApi-MacibuMateriali",
                routeTemplate: "api/avengers/macibu-materiali/{id}",
                defaults: new { controller = "MacibuMateriali", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "AvengersApi-Prieksmeti",
                routeTemplate: "api/avengers/prieksmeti/{id}",
                defaults: new { controller = "Prieksmeti", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "AvengersApi-ReaktivasVielas",
                routeTemplate: "api/avengers/reaktivas-vielas/{id}",
                defaults: new { controller = "ReaktivasVielas", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "AvengersApi-Trauki",
                routeTemplate: "api/avengers/trauki/{id}",
                defaults: new { controller = "Trauki2", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DeadpoolApi-InventaraTipiController",
                routeTemplate: "api/deadpool/inventara-tipi/{id}",
                defaults: new { controller = "InventaraTipi", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DeadpoolApi-KabinetaInventarsController",
                routeTemplate: "api/deadpool/kabineta-inventars/{id}",
                defaults: new { controller = "KabinetaInventars", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DeadpoolApi-KabinetiController",
                routeTemplate: "api/deadpool/kabineti/{id}",
                defaults: new { controller = "Kabineti", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DeadpoolApi-LietotajiController",
                routeTemplate: "api/deadpool/lietotaji/{id}",
                defaults: new { controller = "Lietotaji", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "IronManApi-AtbildīgaisController",
                routeTemplate: "api/iron-man/atbildigais/{id}",
                defaults: new { controller = "Atbildīgais", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "IronManApi-IekartasController",
                routeTemplate: "api/iron-man/iekartas/{id}",
                defaults: new { controller = "Iekartas2", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "IronManApi-KabinetsController",
                routeTemplate: "api/iron-man/kabinets/{id}",
                defaults: new { controller = "Kabinets", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "IronManApi-ObjektsController",
                routeTemplate: "api/iron-man/objekts/{id}",
                defaults: new { controller = "Objekts", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "IronManApi-PiederumisController",
                routeTemplate: "api/iron-man/piederumi/{id}",
                defaults: new { controller = "Piederumis", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "IronManApi-ReagentiController",
                routeTemplate: "api/iron-man/reagenti/{id}",
                defaults: new { controller = "Reagenti", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "IronManApi-TraukiController",
                routeTemplate: "api/iron-man/trauki/{id}",
                defaults: new { controller = "Trauki", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "WolverineApi-KlientiController",
                routeTemplate: "api/wolverine/klienti/{id}",
                defaults: new { controller = "Klienti", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "WolverineApi-LaivaController",
                routeTemplate: "api/wolverine/laiva/{id}",
                defaults: new { controller = "Laiva", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "WolverineApi-LaivuVeidiController",
                routeTemplate: "api/wolverine/laivu-veidi/{id}",
                defaults: new { controller = "LaivuVeidi", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "WolverineApi-PasutijumiController",
                routeTemplate: "api/wolverine/pasutijumi/{id}",
                defaults: new { controller = "Pasutijumi", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "WolverineApi-PiekabesController",
                routeTemplate: "api/wolverine/piekabes/{id}",
                defaults: new { controller = "Piekabes", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "WolverineApi-PiekabesVeidsController",
                routeTemplate: "api/wolverine/piekabes-veids/{id}",
                defaults: new { controller = "PiekabesVeids", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "WolverineApi-SoferiController",
                routeTemplate: "api/wolverine/soferi/{id}",
                defaults: new { controller = "Soferi", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "WolverineApi-TransportlidzekliController",
                routeTemplate: "api/wolverine/transportlidzekli/{id}",
                defaults: new { controller = "Transportlidzekli", id = RouteParameter.Optional }
            );
        }
    }
}
