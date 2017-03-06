namespace SoftUniGameStore.App.Data
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using Contracts;
    using Models;

    public class GameStoreContext : DbContext, IGameStoreContext
    {
        public GameStoreContext()
            :base("name=GameStoreContext")
        {
            
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Session> Logins { get; set; }

        public IDbSet<Game> Games { get; set; }

        public IDbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }

        public DbContext DbContext => this;

        public IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}