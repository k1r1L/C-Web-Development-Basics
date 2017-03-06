namespace SimpleMVC.App.MVC
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;

    public static class UrlParser
    {
        public static IDictionary<string, string> RetrieveRequestParams(string queryString)
        {
            queryString = WebUtility.UrlDecode(queryString);
            Dictionary<string, string> requestParams = new Dictionary<string, string>();
            string[] keyValuePairs = queryString.Split('&');
            foreach (string pair in keyValuePairs)
            {
                string key = pair.Split('=')[0];
                string value = pair.Split('=')[1];
                if (!requestParams.ContainsKey(key))
                {
                    requestParams.Add(key, value);
                }
                else
                {
                    requestParams[key] = value;
                }
            }

            return requestParams;
        }

        public static string[] RetrieveUrlParams(string url)
        {
            url = WebUtility.UrlDecode(url);
            string[] urlParams;
            if (url.Contains('?'))
            {
                 urlParams = url.Substring(0, url.IndexOf('?')).Split('/');
            }
            else
            {
                urlParams = url.Split('/');
            }

            return urlParams;
        }

        public static string ReturnWithCapitalLetter(string value)
        {
            string valueWithCapitalLetter = value[0].ToString().ToUpper() + value.Substring(1);

            return valueWithCapitalLetter;
        }
    }
}
