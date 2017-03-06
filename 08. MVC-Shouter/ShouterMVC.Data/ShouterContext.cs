namespace ShouterMVC.Data
{
    using System.Data.Entity;
    using Contracts;
    using Models;

    public class ShouterContext : DbContext, IShouterContext
    {
        public ShouterContext()
            : base("name=ShouterContext")
        {
            
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Login> Logins { get; set; }

        public IDbSet<Shout> Shouts { get; set; }

        public DbContext DbContext { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(user => user.Following)
                .WithMany(user => user.Followers);

            modelBuilder.Entity<User>()
              .HasMany(user => user.Followers)
              .WithMany(user => user.Following);

            base.OnModelCreating(modelBuilder);
        }

        public  IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public void Detach<T>(T entry) where T : class
        {
            this.Entry(entry).State = EntityState.Deleted;
        }
    }
}