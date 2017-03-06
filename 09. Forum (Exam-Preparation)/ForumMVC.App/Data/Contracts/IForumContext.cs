namespace ForumMVC.App.Data.Contracts
{
    using System.Data.Entity;
    using Models;

    public interface IForumContext
    {
        IDbSet<User> Users { get; }
        IDbSet<Login> Logins { get; }

        IDbSet<Topic> Topics { get; }

        IDbSet<Category> Categories { get; }

        IDbSet<Reply> Replies { get; }

        DbContext DbContext { get; }

        int SaveChanges();
        IDbSet<T> Set<T>()
           where T : class;

        void Detach<T>(T entry)
            where T : class;
    }
}
