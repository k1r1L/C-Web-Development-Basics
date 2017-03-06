namespace SoftUniGameStore.App.Data.Repositories
{
    using Contracts;
    using Models;

    public class CartRepository : BaseRepository<Cart>
    {
        public CartRepository(IGameStoreContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
