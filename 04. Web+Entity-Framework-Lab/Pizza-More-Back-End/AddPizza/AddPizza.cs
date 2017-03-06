namespace AddPizza
{
    using PizzaMore.Data;
    using PizzaMore.Models;
    using PizzaMore.Utility;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AddPizza
    {
        public static Header Header;
        public static Session Session;

        public static void Main(string[] args)
        {
            Header = new Header();
            Header.Print();
            Session = WebUtil.GetSession();

            if (Session == null)
            {
                WebUtil.PageNotAllowed();
            }
            else
            {
                if (WebUtil.IsPost())
                {
                    IDictionary<string, string> postParameters = WebUtil.RetrievePostParameters();

                    using (PizzaMoreContext context = new PizzaMoreContext())
                    {
                        string pizzaTitle = postParameters["title"];
                        string pizzaRecipe = postParameters["recipe"];
                        string pizzaUrl = postParameters["url"];
                        User owner = context.Users.Find(Session.UserId);
                        //context.Entry(owner).State = EntityState.Unchanged;
                        Pizza pizzaEntity = new Pizza()
                        {
                            Title = pizzaTitle,
                            Recipe = pizzaRecipe,
                            ImageUrl = pizzaUrl,
                            Owner = owner,
                            OwnerId = owner.Id
                        };

                        context.Pizzas.Add(pizzaEntity);
                        context.SaveChanges();

                    }
                    
                }

                WebUtil.PrintFileContent(Constants.AddPizzaPageLocation);
            }
        }

    }
}
