using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace API_DES_BOOK
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "GetAllBooks",
                routeTemplate: "Book/GetAllBooks",
                defaults: new { controller = "Book", action = "GetAllBooks" }
            );

            config.Routes.MapHttpRoute(
                name: "GetBookById",
                routeTemplate: "Book/GetBookById/{id}",
                defaults: new { controller = "Book", action = "GetBookById" },
                constraints: new { id = @"\d+" } // Solo permite números en {id}
            );

            config.Routes.MapHttpRoute(
                name: "CreateBook",
                routeTemplate: "Book/CreateBook",
                defaults: new { controller = "Book", action = "CreateBook" }
            );

            config.Routes.MapHttpRoute(
                name: "UpdateBook",
                routeTemplate: "Book/UpdateBook/{id}",
                defaults: new { controller = "Book", action = "UpdateBook" },
                constraints: new { id = @"\d+" } // Solo permite números en {id}
            );

            config.Routes.MapHttpRoute(
                name: "DeleteBook",
                routeTemplate: "Book/DeleteBook/{id}",
                defaults: new { controller = "Book", action = "DeleteBook" },
                constraints: new { id = @"\d+" } // Solo permite números en {id}
            );
        }
    }
}
