namespace Home
{
    using System;
    using System.Collections.Generic;
    using PizzaMore.Models;
    using PizzaMore.Utility;
    using PizzaMore.Data;
    using System.Linq;

    public class Home
    {
        private static IDictionary<string, string> RequestParameters;
        private static Session Session;
        private static Header Header = new Header();
        private static string Language;
        static void Main()
        {
            AddDefaultLanguageCookie();

            if (WebUtil.IsGet())
            {
                RequestParameters = WebUtil.RetrieveGetParameters();
                TryLogOut();
                Language = WebUtil.GetCookies()["lang"].Value;
            }
            else if (WebUtil.IsPost())
            {
                RequestParameters = WebUtil.RetrievePostParameters();
                Header.AddCookie(new Cookie("lang", RequestParameters["language"]));
                Language = RequestParameters["language"];
            }

            ShowPage();
        }
        private static void AddDefaultLanguageCookie()
        {
            if (!WebUtil.GetCookies().ContainsKey("lang"))
            {
                Header.AddCookie(new Cookie("lang", "EN"));
                Language = "EN";
                ShowPage();
            }
        }

        private static void ShowPage()
        {
            Header.Print();
            if (Language.Equals("DE"))
            {
                ServeHomeDe();
            }
            else
            {
                ServeHtmlEn();
            }
        }

        private static void ServeHomeDe()
        {
            WebUtil.PrintFileContent(Constants.HomeDeHtmlLocation);
        }

        private static void ServeHtmlEn()
        {
            WebUtil.PrintFileContent(Constants.HomeEnHtmlLocation);
        }
        private static void TryLogOut()
        {
            if (RequestParameters.ContainsKey("logout"))
            {
                if (RequestParameters["logout"] == "true")
                {
                    Session = WebUtil.GetSession();
                    using (var context = new PizzaMoreContext())
                    {
                        var s = context.Sessions.Find(Session.Id);
                        context.Sessions.Remove(s);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
