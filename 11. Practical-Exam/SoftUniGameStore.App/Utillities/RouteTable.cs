namespace SoftUniGameStore.App.Utillities
{
    using System.Collections.Generic;
    using System.IO;
    using SimpleHttpServer.Enums;
    using SimpleHttpServer.Models;
    using SimpleMVC.Routers;

    namespace IssueTracker.App.Utillities
    {
        public class RouteTable
        {
            public static IEnumerable<Route> Routes
            {
                get
                {
                    return new Route[]
                    {
                    new Route()
                    {
                        Name = "JS",
                        Method = RequestMethod.GET,
                        UrlRegex = "/js/bootstrap.min.js$",
                        Callable = (request) =>
                        {
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText("../../content/js/bootstrap.min.js")
                            };
                            response.Header.ContentType = "application/x-javascript";
                            return response;
                        }
                    },
                    new Route()
                    {
                        Name = "Jquery",
                        Method = RequestMethod.GET,
                        UrlRegex = "/scripts/jquery-3.1.1.min.js$",
                        Callable = (request) =>
                        {
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText("../../content/scripts/jquery-3.1.1.min.js")
                            };
                            response.Header.ContentType = "application/x-javascript";
                            return response;
                        }
                    },
                    new Route()
                    {
                        Name = "Bootstrap CSS",
                        Method = RequestMethod.GET,
                        UrlRegex = "/css/bootstrap.min.css$",
                        Callable = (request) =>
                        {
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText("../../content/css/bootstrap.min.css")
                            };
                            response.Header.ContentType = "text/css";
                            return response;
                        }
                    },
                    new Route()
                    {
                        Name = "Controller/Action/GET",
                        Method = RequestMethod.GET,
                        UrlRegex = @"^/(.+)/(.+)$",
                        Callable = new ControllerRouter().Handle
                    },
                    new Route()
                    {
                        Name = "Controller/Action/POST",
                        Method = RequestMethod.POST,
                        UrlRegex = @"^/(.+)/(.+)$",
                        Callable = new ControllerRouter().Handle
                    }
                    };
                }
            }
        }
    }

}
