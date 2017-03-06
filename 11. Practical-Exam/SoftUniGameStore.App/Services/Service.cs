namespace SoftUniGameStore.App.Services
{
    using System.Linq;
    using Data;
    using Data.Contracts;
    using Data.Repositories;
    using Models;
    using SimpleHttpServer.Models;

    public abstract class Service
    {
        private readonly IGameStoreContext context;

        protected Service()
            : this(new GameStoreContext())
        {
          
        }

        protected Service(IGameStoreContext context)
        {
            this.context = context;
        }

        protected UserRepository UserRepository => new UserRepository(this.context);

        protected SessionRepository SessionRepository => new SessionRepository(this.context);

        protected GameRepository GameRepository => new GameRepository(this.context);

        protected CartRepository CartRepository => new CartRepository(this.context);


        protected IGameStoreContext Context => this.context;

        protected int SaveChanges() => this.context.SaveChanges();

        public bool IsAuthenticated(HttpSession httpSession)
        {
            Session session = this.context.Logins
                .FirstOrDefault(l => l.IsActive && l.SessionId == httpSession.Id);

            if (session == null)
            {
                return false;
            }

            return true;
        }

        public bool IsAdmin()
        {
            User existingUser = this.SessionRepository.RetrieveCurrentlyLogged();

            return existingUser.Role == Role.Admin;
        }

    }
}
