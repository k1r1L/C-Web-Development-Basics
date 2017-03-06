namespace ForumMVC.App.Data.Repositories
{
    using Contracts;
    using Models;

    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(IForumContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
