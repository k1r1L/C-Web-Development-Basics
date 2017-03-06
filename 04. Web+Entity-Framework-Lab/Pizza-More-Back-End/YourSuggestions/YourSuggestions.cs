namespace YourSuggestions
{
    using PizzaMore.Data;
    using PizzaMore.Models;
    using PizzaMore.Utility;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class YourSuggestions
    {
        public static Header Header;
        public static Session Session;

        public static void Main(string[] args)
        {
            Header = new Header();
            Session = WebUtil.GetSession();

            if (Session == null)
            {
                Header.Print();
                WebUtil.PageNotAllowed();
            }
            else
            {
                if (WebUtil.IsPost())
                {
                    var requestParams = WebUtil.RetrievePostParameters();
                    DeletePizza(requestParams);
                }

                ShowPage();
            }
        }

        private static void DeletePizza(IDictionary<string, string> requestParams)
        {
            int pizzaId = int.Parse(requestParams["pizzaId"]);
            using (PizzaMoreContext context = new PizzaMoreContext())
            {
                Pizza pizzaEntity = context.Pizzas.Find(pizzaId);
                context.Pizzas.Remove(pizzaEntity);
                context.SaveChanges();
            }
        }

        private static void ShowPage()
        {
            Header.Print();
            WebUtil.PrintFileContent(Constants.YourSuggestionTopLocation);
            PrintListOfSuggestedItems();
            WebUtil.PrintFileContent(Constants.YourSuggestionBottomLocation);
        }

        private static void PrintListOfSuggestedItems()
        {
            using (PizzaMoreContext context = new PizzaMoreContext())
            {
                List<Pizza> suggestions = context.Users.Find(Session.UserId).Suggestions.ToList();
                Console.WriteLine("<ul>");
                foreach (var suggestion in suggestions)
                {
                    Console.WriteLine("<form method=\"POST\">");
                    Console.WriteLine($"<li><a href=\"DetailsPizza.exe?pizzaid={suggestion.Id}\">{suggestion.Title}</a> <input type=\"hidden\" name=\"pizzaId\" value=\"{suggestion.Id}\"/> <input type=\"submit\" class=\"btn btn-sm btn-danger\" value=\"X\"/></li>");
                    Console.WriteLine("</form>");
                }
                Console.WriteLine("</ul>");
            }

        }
    }
}
