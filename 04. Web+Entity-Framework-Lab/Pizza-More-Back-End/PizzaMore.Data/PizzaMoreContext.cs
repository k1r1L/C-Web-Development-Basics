namespace PizzaMore.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PizzaMoreContext : DbContext
    {
        public PizzaMoreContext()
            : base("name=PizzaMoreContext")
        {
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Pizza> Pizzas { get; set; }

        public IDbSet<Session> Sessions { get; set; }
    }
}