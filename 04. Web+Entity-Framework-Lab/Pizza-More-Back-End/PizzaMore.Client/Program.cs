namespace PizzaMore.Client
{
    using PizzaMore.Data;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            PizzaMoreContext context = new PizzaMoreContext();
            context.Database.Initialize(true);
        }
    }
}
