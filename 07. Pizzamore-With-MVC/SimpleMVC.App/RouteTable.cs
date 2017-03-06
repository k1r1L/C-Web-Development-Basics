﻿namespace SimpleMVC.App
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
    using System.IO;
    using System.Net.Http;

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
                        UrlRegex = @"^/home/(.+)",
                        Callable = new ControllerRouter().Handle
                    },
                    new Route()
                    {
                        Name = "Controller/Action/POST",
                        Method = RequestMethod.POST,
                        UrlRegex = @"^/home/(.+)",
                        Callable = new ControllerRouter().Handle
                    },
                     new Route()
                    {
                        Name = "Controller/Action/GET",
                        Method = RequestMethod.GET,
                        UrlRegex = @"^/users/(.+)",
                        Callable = new ControllerRouter().Handle
                    },
                    new Route()
                    {
                        Name = "Controller/Action/POST",
                        Method = RequestMethod.POST,
                        UrlRegex = @"^/users/(.+)",
                        Callable = new ControllerRouter().Handle
                    },
                    new Route()
                    {
                        Name = "Controller/Action/GET",
                        Method = RequestMethod.GET,
                        UrlRegex = @"^/menu/(.+)",
                        Callable = new ControllerRouter().Handle
                    },
                    new Route()
                    {
                        Name = "Controller/Action/POST",
                        Method = RequestMethod.POST,
                        UrlRegex = @"^/menu/(.+)",
                        Callable = new ControllerRouter().Handle
                    },
                      new Route()
                    {
                        Name = "Controller/Action/GET",
                        Method = RequestMethod.GET,
                        UrlRegex = @"^/game/index$",
                        Callable = new ControllerRouter().Handle
                    },
                      new Route()
                    {
                         Name = "Bootstrap JS",
                         Method = RequestMethod.GET,
                         UrlRegex = "^/bootstrap/js/bootstrap.min.js$",
                         Callable = (request) =>
                         {
                        var response = new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("C:/Users/v/Desktop/SoftUni/C# Web/Web Development Basics/06. Pizzamore-With-MVC/SimpleMVC.App/Content/bootstrap/js/bootstrap.min.js")
                        };
                            response.Header.ContentType = "application/x-javascript";
                            return response;
                        }
                    },
                     new Route()
                    {
                         Name = "Jquery",
                         Method = RequestMethod.GET,
                         UrlRegex = "^/jquery/jquery-3.1.1.js$",
                         Callable = (request) =>
                         {
                        var response = new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("C:/Users/v/Desktop/SoftUni/C# Web/Web Development Basics/06. Pizzamore-With-MVC/SimpleMVC.App/Content/bootstrap/js/bootstrap.min.js")
                        };
                            response.Header.ContentType = "application/x-javascript";
                            return response;
                        }
                    },
                    new Route()
                    {
                         Name = "Bootstrap CSS",
                         Method = RequestMethod.GET,
                         UrlRegex = "^/bootstrap/css/bootstrap.min.css$",
                         Callable = (request) =>
                    {
                        var response = new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("C:/Users/v/Desktop/SoftUni/C# Web/Web Development Basics/06. Pizzamore-With-MVC/SimpleMVC.App/Content/bootstrap/css/bootstrap.min.css")
                        };
                        response.Header.ContentType = "text/css";
                        return response;
                    }
                }, new Route()
                {
                    Name = "Custom CSS's",
                    Method = RequestMethod.GET,
                    UrlRegex = @"^/css/.+\.css$",
                    Callable = (request) =>
                    {
                        string nameOfCssFile = request.Url.Substring(request.Url.LastIndexOf('/') + 1);
                        var response = new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText($"C:/Users/v/Desktop/SoftUni/C# Web/Web Development Basics/06. Pizzamore-With-MVC/SimpleMVC.App/Content/css/{nameOfCssFile}")
                        };
                        response.Header.ContentType = "text/css";
                        return response;
                    }
                },
                  new Route()
                {
                    Name = "Images",
                    Method = RequestMethod.GET,
                    UrlRegex = @"^/images/.+\.jpg$",
                    Callable = (request) =>
                    {
                        string nameOfImage = request.Url.Substring(request.Url.LastIndexOf('/') + 1);
                        var response = new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            Content = File.ReadAllBytes($"C:/Users/v/Desktop/SoftUni/C# Web/Web Development Basics/06. Pizzamore-With-MVC/SimpleMVC.App/Content/images/{nameOfImage}")
                        };
                        response.Header.ContentType = "image/jpeg";

                        return response;
                    }
                }
                };           
            }
        }
    }
}
