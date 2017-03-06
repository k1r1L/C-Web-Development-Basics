namespace PizzaMore.Utility
{
    using Data;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.IO;
    using Models;
    using System.Linq;
    public static class WebUtil
    {
        private static readonly PizzaMoreContext database = new PizzaMoreContext();

        public static bool IsPost()
        {
            string requestMethod = Environment.GetEnvironmentVariable("REQUEST_METHOD").ToLower();

            return requestMethod.Equals("post");
        }

        public static bool IsGet()
        {
            string requestMethod = Environment.GetEnvironmentVariable("REQUEST_METHOD").ToLower();

            return requestMethod.Equals("get");
        }

        public static IDictionary<string, string> RetrieveGetParameters()
        {
            string queryString = WebUtility.UrlDecode(Environment.GetEnvironmentVariable("QUERY_STRING"));
            Dictionary<string, string> nameAndValue = RetrieveRequestParameters(queryString);

            return nameAndValue;
        }

        public static IDictionary<string, string> RetrievePostParameters()
        {
            string queryString = WebUtility.UrlDecode(Console.ReadLine());
            Dictionary<string, string> nameAndValue = RetrieveRequestParameters(queryString);

            return nameAndValue;
        }
        
        public static Dictionary<string, string> RetrieveRequestParameters(string queryString)
        {
            Dictionary<string, string> requestParameters = new Dictionary<string, string>();
            string[] parameters = queryString.Split('&');
            foreach (var param in parameters)
            {
                string[] pair = param.Split('=');

                string name = pair[0];
                string value = null;

                if (pair.Length > 1)
                {
                    value = pair[1];
                }

                if (!requestParameters.ContainsKey(name))
                {
                    requestParameters.Add(name, value);
                }
            }

            return requestParameters;
        }

        public static ICookieCollection GetCookies()
        {
            string cookieString = Environment.GetEnvironmentVariable("HTTP_COOKIE");
            if (string.IsNullOrEmpty(cookieString))
            {
                return new CookieCollection();
            }

            var cookies = new CookieCollection();
            string[] cookieSaves = cookieString.Split(';');
            foreach (var cookieSave in cookieSaves)
            {
                string[] cookiePair = cookieSave.Split('=').Select(x => x.Trim()).ToArray();
                var cookie = new Cookie(cookiePair[0], cookiePair[1]);
                cookies.AddCookie(cookie);
            }

            return cookies;
        }

        public static Session GetSession()
        {
            ICookieCollection cookieCollection = GetCookies();

            if (cookieCollection.ContainsKey("sid"))
            {
                Cookie cookie = cookieCollection["sid"];
                Session session = database.Sessions.Find(int.Parse(cookie.Value));

                return session;
            }

            return null;
        }

        public static void PrintFileContent(string path)
        {
            string text = File.ReadAllText(path);
            Console.WriteLine(text);
        }

        public static void PageNotAllowed()
        {
            PrintFileContent(Constants.GameLocation);
        }
    }
}
