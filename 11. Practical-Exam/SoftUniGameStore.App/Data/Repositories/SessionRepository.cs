namespace SoftUniGameStore.App.Data.Repositories
{
    using System.Linq;
    using Contracts;
    using Models;

    public class SessionRepository : BaseRepository<Session>
    {
        public SessionRepository(IGameStoreContext dbContext)
            : base(dbContext)
        {
        }

        public User RetrieveCurrentlyLogged()
        {
            Session lastSession = this.entityTable.FirstOrDefault(l => l.IsActive);

            return lastSession?.User;
        }
    }
}
