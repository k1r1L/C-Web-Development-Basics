namespace Menu
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using PizzaMore.Data;
    using PizzaMore.Models;
    using PizzaMore.Utility;

    public class Menu
    {
        public static Header Header;
        public static Session Session;
        public static User SessionUser;
        public static List<Pizza> Pizzas;

        public static void Main(string[] args)
        {
            Header = new Header();
            Session = WebUtil.GetSession();

            if (Session == null)
            {
                ShowGame();
            }
            else
            {
                if (WebUtil.IsPost())
                {
                    IDictionary<string, string> requestParams = WebUtil.RetrievePostParameters();
                    VoteForPizza(requestParams);
                }

                using (PizzaMoreContext context = new PizzaMoreContext())
                {
                    ICookieCollection collection = WebUtil.GetCookies();
                    foreach (Cookie cookie in collection)
                    {
                        Header.AddCookie(cookie);
                    }

                    Pizzas = context.Pizzas.ToList();
                    SessionUser = context.Users.Find(Session.UserId);
                }

                ShowPage();
            }
        }

        private static void VoteForPizza(IDictionary<string, string> requestParams)
        {
            string pizzaVote = requestParams["pizzaVote"];
            int pizzaId = int.Parse(requestParams["pizzaid"]);
            using (PizzaMoreContext context = new PizzaMoreContext())
            {
                Pizza pizzaEntity = context.Pizzas.Find(pizzaId);
                if (pizzaVote == "up")
                {
                    pizzaEntity.UpVotes++;
                }
                else
                {
                    pizzaEntity.DownVotes++;
                }

                context.SaveChanges();
            }
        }

        private static void ShowGame()
        {
            Header.Print();
            WebUtil.PageNotAllowed();
        }

        private static void ShowPage()
        {
            Header.Print();
            GenerateNavbar();
            WebUtil.PrintFileContent(Constants.MenuTopPageLocation);
            GenerateAllSuggestions();
            WebUtil.PrintFileContent(Constants.MenuBottomPageLocation);
        }

        private static void GenerateAllSuggestions()
        {

            Console.WriteLine("<div class=\"card-deck\">");
            foreach (var pizza in Pizzas)
            {
                Console.WriteLine("<div class=\"card\">");
                Console.WriteLine($"<img class=\"card-img-top\" src=\"{pizza.ImageUrl}\" width=\"200px\"alt=\"Card image cap\">");
                Console.WriteLine("<div class=\"card-block\">"); Console.WriteLine($"<h4 class=\"card-title\">{pizza.Title}</h4>");
                Console.WriteLine($"<p class=\"card-text\"><a href=\"DetailsPizza.exe?pizzaid={pizza.Id}\">Recipe</a></p>");
                Console.WriteLine("<form method=\"POST\">");
                Console.WriteLine($"<div class=\"radio\"><label><input type = \"radio\" name=\"pizzaVote\" value=\"up\">Up</label></div>");
                Console.WriteLine($"<div class=\"radio\"><label><input type = \"radio\" name=\"pizzaVote\" value=\"down\">Down</label></div>");
                Console.WriteLine($"<input type=\"hidden\" name=\"pizzaid\" value=\"{pizza.Id}\" />");
                Console.WriteLine("<input type=\"submit\" class=\"btn btn-primary\" value=\"Vote\" />");
                Console.WriteLine("</form>");
                Console.WriteLine("</div>");
                Console.WriteLine("</div>");
            }
            Console.WriteLine("</div>");

        }

        private static void GenerateNavbar()
        {
            Console.WriteLine("<nav class=\"navbar navbar-default\">" +
                "<div class=\"container-fluid\">" +
                "<div class=\"navbar-header\">" +
                "<a class=\"navbar-brand\" href=\"Home.exe\">PizzaMore</a>" +
                "</div>" +
                "<div class=\"collapse navbar-collapse\" id=\"bs-example-navbar-collapse-1\">" +
                "<ul class=\"nav navbar-nav\">" +
                "<li ><a href=\"AddPizza.exe\">Suggest Pizza</a></li>" +
                "<li><a href=\"YourSuggestions.exe\">Your Suggestions</a></li>" +
                "</ul>" +
                "<ul class=\"nav navbar-nav navbar-right\">" +
                "<p class=\"navbar-text navbar-right\"></p>" +
                "<p class=\"navbar-text navbar-right\"><a href=\"Home.exe?logout=true\" class=\"navbar-link\">Sign Out</a></p>" +
                $"<p class=\"navbar-text navbar-right\">Signed in as {Session.User.Email}</p>" +
                "</ul> </div></div></nav>");

        }
    }
}
