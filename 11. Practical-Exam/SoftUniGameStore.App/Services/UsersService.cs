namespace SoftUniGameStore.App.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using BindingModels;
    using Models;
    using ViewModels;

    public class UsersService : Service
    {
        public void RegisterUser(RegisterUserBindingModel rubm)
        {
            bool isAdmin = !this.UserRepository.All().Any();
            User existingUser = this.UserRepository.Find(u => u.Email == rubm.Email);
            if (existingUser != null)
            {
                return;
            }

            User userEntity = new User()
            {
                FullName = rubm.FullName,
                Email = rubm.Email,
                Password = rubm.Password,
                Role = isAdmin ? Role.Admin : Role.Regular
            };

            this.UserRepository.Insert(userEntity);
            this.SaveChanges();
        }

        public bool CanLogin(LoginUserBindingModel lubm)
        {
            return this.UserRepository.FindByEmailAndPassword(lubm.Email, lubm.Password) != null;
        }

        public void LoginUser(LoginUserBindingModel lubm, string sessionId)
        {
            User existingUser = this.UserRepository.FindByEmailAndPassword(lubm.Email, lubm.Password);
            if (this.SessionRepository.All().Any(l => l.User.Id == existingUser.Id))
            {
                Session s = this.SessionRepository.Find(l => l.User.Id == existingUser.Id);
                s.IsActive = true;
                this.SaveChanges();
            }
            else
            {
                Session session = new Session()
                {
                    IsActive = true,
                    SessionId = sessionId,
                    User = existingUser
                };

                this.SessionRepository.Insert(session);
                this.SaveChanges();
            }
        }

        public void LogoutUser(string sessionId)
        {
            User currentUser = this.SessionRepository.RetrieveCurrentlyLogged();
            Session sessionEntity = this.SessionRepository
               .Find(l => l.UserId == currentUser.Id);

            sessionEntity.IsActive = false;
            this.SaveChanges();
        }

        public ProfileViewModel ReturnProfileViewModel()
        {
            User currentUser = this.SessionRepository.RetrieveCurrentlyLogged();
            List<Game> userGames = currentUser.Games.ToList();
            List<GameProfileViewModel> gameViewModels = new List<GameProfileViewModel>();
            foreach (Game gameEntity in userGames)
            {
                gameViewModels.Add(Mapper.Map<GameProfileViewModel>(gameEntity));
            }

            return new ProfileViewModel()
            {
                Games = gameViewModels,
                IsAdmin = this.IsAdmin()
            };
        }
    }
}
