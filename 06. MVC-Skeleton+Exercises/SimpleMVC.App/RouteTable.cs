namespace SimpleMVC.App
{
    using SimpleHttpServer.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SimpleHttpServer.Enums;
    using MVC.Controllers;
    using MVC.Routers;

    public static class RouteTable
    {

        public static IEnumerable<Route> Routes
        {
            get
            {
                return new Route[]
                {
                    new Route()
                    {
                        Name = "Controller/Action/GET",
                        Method = RequestMethod.GET,
                        UrlRegex = @"^/(.+)/(.+)",
                        Callable = new ControllerRouter().Handle
                    },
                    new Route()
                    {
                        Name = "Controller/Action/POST",
                        Method = RequestMethod.POST,
                        UrlRegex = @"^/(.+)/(.+)",
                        Callable = new ControllerRouter().Handle
                    }
                };
            }
        }
    }
}
