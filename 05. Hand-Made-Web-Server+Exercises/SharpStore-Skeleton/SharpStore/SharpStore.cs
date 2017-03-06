namespace SharpStore
{
    using System;
    using System.IO;
    using SimpleHttpServer;
    using SimpleHttpServer.Enums;
    using SimpleHttpServer.Models;
    using System.Collections.Generic;
    using Data;
    using Utilities;

    public class SharpStore
    {
        static void Main(string[] args)
        {
            //InitializeDatabase();

            var routes = new List<Route>()
            {
                new Route()
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
                            ContentAsUTF8 = File.ReadAllText($"../../content/css/{nameOfCssFile}")
                        };
                        response.Header.ContentType = "text/css";
                        return response;
                    }
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
                            ContentAsUTF8 = File.ReadAllText("../../content/bootstrap/js/bootstrap.min.js")
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
                            ContentAsUTF8 = File.ReadAllText("../../content/bootstrap/css/bootstrap.min.css")
                        };
                        response.Header.ContentType = "text/css";
                        return response;
                    }
                },
                new Route()
                {
                    Name = "Home html",
                    Method = RequestMethod.GET,
                    UrlRegex = @"^\/home\.html(\?theme=dark)*|\/home-default.html(\?theme=light)*$",
                    Callable = (request) =>
                    {
                        if (request.Url.IndexOf('?') == -1)
                        {
                            return new HttpResponse()
                            {
                               StatusCode = ResponseStatusCode.Ok,
                               ContentAsUTF8 = GetHtmlPage(request.Header, "home")
                            };
                        }

                         var response =  new HttpResponse()
                         {
                            StatusCode = ResponseStatusCode.Ok,
                         };

                        string[] urlPairs = request.Url.Split('?');
                        string htmlFile = urlPairs[0];
                        string cookieTheme = urlPairs[1].Split('=')[1];

                        ChangeCookie(response.Header, cookieTheme);
                        response.ContentAsUTF8 = File.ReadAllText($"../../content/{htmlFile}");

                        return response;
                    }
                },
                new Route()
                {
                    Name = "About html",
                    Method = RequestMethod.GET,
                    UrlRegex = @"^\/about\.html(\?theme=dark)*|\/about-default.html(\?theme=light)*$",
                    Callable = (request) =>
                    {
                        if (request.Url.IndexOf('?') == -1)
                        {
                            return new HttpResponse()
                            {
                               StatusCode = ResponseStatusCode.Ok,
                               ContentAsUTF8 = GetHtmlPage(request.Header, "about")
                            };
                        }
                        string[] urlPairs = request.Url.Split('?');
                        string htmlFile = urlPairs[0];
                        string cookieTheme = urlPairs[1].Split('=')[1];

                         var response =  new HttpResponse()
                         {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText($"../../content/{htmlFile}")
                         };

                        ChangeCookie(response.Header, cookieTheme);

                        return response;
                    }
                },
                new Route()
                {
                    Name = "Contacts html get",
                    Method = RequestMethod.GET,
                    UrlRegex = @"^\/contacts\.html(\?theme=dark)*|\/contacts-default.html(\?theme=light)*$",
                    Callable = (request) =>
                    {
                        if (request.Url.IndexOf('?') == -1)
                        {
                            return new HttpResponse()
                            {
                               StatusCode = ResponseStatusCode.Ok,
                               ContentAsUTF8 = GetHtmlPage(request.Header, "contacts")
                            };
                        }
                        string[] urlPairs = request.Url.Split('?');
                        string htmlFile = urlPairs[0];
                        string cookieTheme = urlPairs[1].Split('=')[1];

                         var response =  new HttpResponse()
                         {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText($"../../content/{htmlFile}")
                         };

                        ChangeCookie(response.Header, cookieTheme);

                        return response;
                    }
                },
                new Route()
                {
                    Name = "Contacts html post",
                    Method = RequestMethod.POST,
                    UrlRegex = @"^\/contacts\.html(\?theme=dark)*|\/contacts-default.html(\?theme=light)*$",
                    Callable = (request) =>
                    {
                        PageUtil.SendMessage(request.Content);
                        if (request.Url.IndexOf('?') == -1)
                        {
                            return new HttpResponse()
                            {
                               StatusCode = ResponseStatusCode.Ok,
                               ContentAsUTF8 = GetHtmlPage(request.Header, "contacts")
                            };
                        }
                        string[] urlPairs = request.Url.Split('?');
                        string htmlFile = urlPairs[0];
                        string cookieTheme = urlPairs[1].Split('=')[1];

                         var response =  new HttpResponse()
                         {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText($"../../content/{htmlFile}")
                         };

                        ChangeCookie(response.Header, cookieTheme);

                        return response;
                    }
                },
                new Route()
                {
                    Name = "Products html get",
                    Method = RequestMethod.GET,
                    UrlRegex = @"^\/products\.html(\?theme=dark)*|\/products-default.html(\?theme=light)*$",
                    Callable = (request) =>
                    {
                         if (request.Url.IndexOf('?') == -1)
                        {
                            return new HttpResponse()
                            {
                               StatusCode = ResponseStatusCode.Ok,
                               ContentAsUTF8 = GetHtmlPage(request.Header, "products")
                            };
                        }
                        string[] urlPairs = request.Url.Split('?');
                        string htmlFile = urlPairs[0];
                        string cookieTheme = urlPairs[1].Split('=')[1];

                         var response =  new HttpResponse()
                         {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = PageUtil.ProductsPageContent(htmlFile)
                         };

                        ChangeCookie(response.Header, cookieTheme);

                        return response;
                    }
                },
                new Route()
                {
                    Name = "Products html post",
                    Method = RequestMethod.POST,
                    UrlRegex = @"^\/products\.html(\?theme=dark)*|\/products-default.html(\?theme=light)*$",
                    Callable = (request) =>
                    {
                        if (request.Url.IndexOf('?') == -1)
                        {
                            return new HttpResponse()
                            {
                               StatusCode = ResponseStatusCode.Ok,
                               ContentAsUTF8 = PageUtil.ProductsPageContent("products.html", request.Content)
                            };
                        }
                        string[] urlPairs = request.Url.Split('?');
                        string htmlFile = urlPairs[0];
                        string cookieTheme = urlPairs[1].Split('=')[1];

                         var response =  new HttpResponse()
                         {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = PageUtil.ProductsPageContent(htmlFile, request.Content)
                         };

                        ChangeCookie(response.Header, cookieTheme);

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
                            Content = File.ReadAllBytes($"../../content/images/{nameOfImage}")
                        };
                        response.Header.ContentType = "image/jpeg";

                        return response;
                    }
                }
            };

            HttpServer httpServer = new HttpServer(8081, routes);
            httpServer.Listen();
        }

        private static void ChangeCookie(Header header, string cookieTheme)
        {
            if (!header.Cookies.Cookies.ContainsKey("theme"))
            {
                header.Cookies.Cookies.Add("theme", new Cookie("theme", cookieTheme));
            }
            else
            {
                header.Cookies.Cookies["theme"] = new Cookie("theme", cookieTheme);
            }
        }

        private static string GetHtmlPage(Header header, string pageName)
        {
            if (!header.Cookies.Cookies.ContainsKey("theme"))
            {
                header.Cookies.Cookies.Add("theme", new Cookie("theme", "dark"));
                if (pageName == "products")
                {
                   return PageUtil.ProductsPageContent(pageName + ".html");
                }

                return File.ReadAllText($"../../content/{pageName}.html");
            }
            else
            {
                string theme = header.Cookies.Cookies["theme"].Value;
                string htmlName = theme == "dark" ? $"{pageName}.html" : $"{pageName}-default.html";
                if (pageName == "products")
                {
                    return PageUtil.ProductsPageContent(htmlName);
                }

                return File.ReadAllText($"../../content/{htmlName}");
            }
        }

        private static void InitializeDatabase()
        {
            using (SharpStoreContext context = new SharpStoreContext())
            {
                context.Database.Initialize(true);
            }
        }
    }
}