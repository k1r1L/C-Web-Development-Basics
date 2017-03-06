namespace SoftUniGameStore.App.Data.Repositories
{
    using Contracts;
    using Models;

    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(IGameStoreContext dbContext) 
            : base(dbContext)
        {
        }

        public User FindByEmailAndPassword(string email, string password)
        {
            User existingUser = this.Find(u => u.Email == email && u.Password == password);

            return existingUser;
        }
    }
}
