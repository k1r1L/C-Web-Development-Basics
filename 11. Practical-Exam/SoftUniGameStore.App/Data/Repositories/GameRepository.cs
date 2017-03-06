namespace SoftUniGameStore.App.Data.Repositories
{
    using Contracts;
    using Models;

    public class GameRepository : BaseRepository<Game>
    {
        public GameRepository(IGameStoreContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
