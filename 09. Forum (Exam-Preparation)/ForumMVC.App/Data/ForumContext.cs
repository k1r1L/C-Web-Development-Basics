namespace ForumMVC.App.Data
{
    using System.Data.Entity;
    using Contracts;
    using Models;

    public class ForumContext : DbContext, IForumContext
    {
        public ForumContext()
            : base("name=ForumContext")
        {
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Login> Logins { get; set; }

        public IDbSet<Topic> Topics { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Reply> Replies { get; set; }

        public DbContext DbContext => this;

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public void Detach<T>(T entry) where T : class
        {
            this.Entry(entry).State = EntityState.Deleted;
        }
    }
}