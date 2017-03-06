namespace SoftUniGameStore.App.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<SoftUniGameStore.App.Data.GameStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SoftUniGameStore.App.Data.GameStoreContext";
        }

        protected override void Seed(SoftUniGameStore.App.Data.GameStoreContext context)
        {
           
        }
    }
}
