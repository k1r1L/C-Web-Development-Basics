namespace ForumMVC.App.Data.Repositories
{
    using Contracts;
    using Models;
    public class ReplyRepository : GenericRepository<Reply>
    {
        public ReplyRepository(IForumContext dbContext)
            : base(dbContext)
        {
        }
    }
}
