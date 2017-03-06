using System.Linq;

namespace ForumMVC.App.Data.Repositories
{
    using Contracts;
    using Models;

    public class TopicRepository : GenericRepository<Topic>
    {
        public TopicRepository(IForumContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<Topic> RetrieveLastTen()
        {
            if (this.entityTable.Count() != 0)
            {
                return
                     this.entityTable.OrderByDescending(t => t.PostedOn).Take(10);
            }

            return this.entityTable;
        }
    }
}
