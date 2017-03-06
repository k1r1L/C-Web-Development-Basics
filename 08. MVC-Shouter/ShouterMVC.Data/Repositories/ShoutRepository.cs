namespace ShouterMVC.Data.Repositories
{
    using Contracts;
    using Models;
    public class ShoutRepository : GenericRepository<Shout>
    {
        public ShoutRepository(IShouterContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
