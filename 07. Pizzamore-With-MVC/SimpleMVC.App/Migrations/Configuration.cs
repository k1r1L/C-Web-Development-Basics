namespace SimpleMVC.App.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SimpleMVC.App.Data.PizzaMoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "SimpleMVC.App.Data.PizzaMoreContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SimpleMVC.App.Data.PizzaMoreContext context)
        {
            
        }
    }
}
