namespace SharpStore.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SharpStore.Data.SharpStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "SharpStore.Data.SharpStoreContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SharpStore.Data.SharpStoreContext context)
        {
            if (context.Knives.Any())
            {
                return;
            }

            Knife knive1 = new Knife()
            {
                Name = "Sharp 300",
                Price = 140,
                ImageUrl = "/images/knive-1.jpg"
            };

            Knife knive2 = new Knife()
            {
                Name = "Sharp 4",
                Price = 99,
                ImageUrl = "/images/knive-2.jpg"
            };

            Knife knive3 = new Knife()
            {
                Name = "Sharp Ultimate",
                Price = 450,
                ImageUrl = "/images/knive-3.jpg"
            };

            context.Knives.Add(knive1);
            context.Knives.Add(knive2);
            context.Knives.Add(knive3);

            context.SaveChanges();
        }
    }
}
