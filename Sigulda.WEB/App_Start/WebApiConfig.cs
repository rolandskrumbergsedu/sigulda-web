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
                defaults: new { controller = "Vadis", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "CaptinAmericaApi-Klase",
                routeTemplate: "api/captain-america/klases/{id}",
                defaults: new { controller = "Klases", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "CaptinAmericaApi-MacibuPrieksmets",
                routeTemplate: "api/captain-america/macibu-prieksmets/{id}",
                defaults: new { controller = "MacibuPrieksmets", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "CaptinAmericaApi-MacibuStunda",
                routeTemplate: "api/captain-america/macibu-stunda/{id}",
                defaults: new { controller = "MacibuStundas", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "CaptinAmericaApi-StundasTema",
                routeTemplate: "api/captain-america/stundas-tema/{id}",
                defaults: new { controller = "StundasTemas", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DeadpoolApi-Atbildigais",
                routeTemplate: "api/deadpool/atbildigais/{id}",
                defaults: new { controller = "Atbildigais", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DeadpoolApi-ElektroniskasIerices",
                routeTemplate: "api/deadpool/elektroniskas-ierices/{id}",
                defaults: new { controller = "ElektroniskasIerices", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DeadpoolApi-Inventars",
                routeTemplate: "api/deadpool/inventars/{id}",
                defaults: new { controller = "Inventars", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DeadpoolApi-Kabinets",
                routeTemplate: "api/deadpool/kabinets/{id}",
                defaults: new { controller = "Kabinets", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "IronManApi-Iekartas",
                routeTemplate: "api/iron-man/iekartas/{id}",
                defaults: new { controller = "Iekartas", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "IronManApi-Piederumi",
                routeTemplate: "api/iron-man/piederumi/{id}",
                defaults: new { controller = "Piederumi", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "IronManApi-Reagenti",
                routeTemplate: "api/iron-man/reagenti/{id}",
                defaults: new { controller = "Reagenti", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "IronManApi-Trauki",
                routeTemplate: "api/iron-man/trauki/{id}",
                defaults: new { controller = "Trauki", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "SpidermanApi-Citi",
                routeTemplate: "api/spiderman/citi/{id}",
                defaults: new { controller = "Citi", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "SpidermanApi-Galdi",
                routeTemplate: "api/spiderman/galdi/{id}",
                defaults: new { controller = "Galdi", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "SpidermanApi-Kresli",
                routeTemplate: "api/spiderman/kresli/{id}",
                defaults: new { controller = "Kresli", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "SpidermanApi-Monitori",
                routeTemplate: "api/spiderman/monitori/{id}",
                defaults: new { controller = "Monitori", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "SpidermanApi-Tafeles",
                routeTemplate: "api/spiderman/tafeles/{id}",
                defaults: new { controller = "Tafeles", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "WolverineApi-Atbildigie",
                routeTemplate: "api/wolverine/atbildigie/{id}",
                defaults: new { controller = "Atbildigie", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
               name: "WolverineApi-ElektroniskasIerices",
               routeTemplate: "api/wolverine/elektroniskas-ierices/{id}",
               defaults: new { controller = "ElektroniskasIerices2", id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
               name: "WolverineApi-Kabinets",
               routeTemplate: "api/wolverine/kabinets/{id}",
               defaults: new { controller = "Kabinets2", id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
               name: "WolverineApi-Mebeles",
               routeTemplate: "api/wolverine/mebeles/{id}",
               defaults: new { controller = "Mebeles", id = RouteParameter.Optional }
           );
        }
    }
}
