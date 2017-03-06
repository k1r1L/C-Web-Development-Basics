namespace SoftUniGameStore.App.Data.Contracts
{
    using System.Data.Entity;
    using Models;

    public interface IGameStoreContext
    {
        IDbSet<User> Users { get; }
        IDbSet<Session> Logins { get; }
        IDbSet<Game> Games { get; }
        IDbSet<Cart> Carts { get; }

        DbContext DbContext { get; }
        int SaveChanges();
        IDbSet<T> Set<T>()
           where T : class;
    }
}
