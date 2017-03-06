namespace ForumMVC.App.Services
{
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.Linq;
    using AutoMapper;
    using BindingModels;
    using Models;
    using SimpleHttpServer.Models;
    using ViewModels;

    public class ForumService : Service
    {
        public bool RegisterUser(RegisterUserBindingModel rubm)
        {
            if (rubm.Password == rubm.ConfirmPassword)
            {
                try
                {
                    ConfigureAutomapper();
                    User userEntity = Mapper.Map<User>(rubm);
                    this.UsersRepository.Insert(userEntity);
                    this.SaveChanges();
                    return true;
                }
                catch (DbEntityValidationException)
                {
                    return false;
                }
            }

            return false;
        }

        public bool LoginUser(LoginUserBindingModel lubm, string sessionId)
        {
            User existingUser = this.UsersRepository
                .Find(u => (u.Username == lubm.Credential || u.Email == lubm.Credential) && u.Password == lubm.Password);

            if (existingUser != null)
            {
                Login loginEntity = new Login()
                {
                    IsActive = true,
                    SessionId = sessionId,
                    User = existingUser
                };
                this.LoginRepository.Insert(loginEntity);
                this.SaveChanges();
                return true;
            }

            return false;
        }

        public void LogoutUser(HttpSession session)
        {
            Login loginEntity = this.LoginRepository
                .Find(l => l.SessionId == session.Id);

            loginEntity.IsActive = false;
            this.SaveChanges();
        }


        public ProfileViewModel RetrieveProfile(int id)
        {
            ProfileViewModel vm = new ProfileViewModel() { UserTopics = new List<TopicViewModel>() };
            List<Topic> topicsForUser = this.UsersRepository.Find(id).Topics.ToList();
            foreach (Topic topic in topicsForUser)
            {
                ConfigureAutomapper(topic);
                vm.UserTopics.Add(Mapper.Map<TopicViewModel>(topic));
            }

            User currentUser = this.LoginRepository.RetrieveCurrentlyLogged();
            if (currentUser.Id == id)
            {
                vm.IsMine = true;
            }

            vm.Username = this.UsersRepository.Find(id).Username;
            return vm;
        }
    }
}
