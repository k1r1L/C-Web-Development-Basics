namespace ForumMVC.App.Data.Repositories
{
    using Contracts;
    using Models;

    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(IForumContext dbContext) 
            : base(dbContext)
        {
        }


    }
}
