namespace ShouterMVC.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using BindingModels.BindingModels;
    using Models;
    using SimpleHttpServer.Models;
    using Tools;
    using ViewModels;

    public class HomeService : Service
    {
        public bool RegisterUser(RegisterUserBindingModel rubm)
        {
            ConfigureMapper(rubm);
            if (rubm.Password == rubm.ConfirmPassword && !this.UsersRepository.ExistsUser(rubm))
            {
                User userEntity = Mapper.Map<User>(rubm);
                try
                {
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
               .Find(u => (u.Username == lubm.Username || u.Email == lubm.Email) && u.Password == lubm.Password);

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

        public MainFeedViewModel RetrieveMainFeed()
        {
            MainFeedViewModel mfvm = new MainFeedViewModel()
            {
                IsLogged = this.LoginRepository.IsLogged()
            };
            List<Shout> everyShout = this.ShoutRepository
                .All()
                .OrderByDescending(s => s.PostedOn)
                .ToList();

            ConfigureMapper();
            foreach (Shout shoutEntity in everyShout)
            {
                ShoutViewModel svm = Mapper.Map<ShoutViewModel>(shoutEntity);
                mfvm.Shouts.Add(svm);
            }

            return mfvm;
        }

        public void LogoutUser(HttpSession session)
        {
            Login loginEntity = this.LoginRepository
                .Find(l => l.SessionId == session.Id);

            loginEntity.IsActive = false;
            this.SaveChanges();
        }

        public void CreateShout(CreateShoutBindingModel csbm)
        {
            try
            {
                Shout shoutEntity = new Shout()
                {
                    Content = csbm.Content,
                    PostedOn = DateTime.Now,
                    Shouter = this.LoginRepository.RetrieveCurrentlyLogged()
                };

                this.ShoutRepository.Insert(shoutEntity);
                this.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                //
            }
        }
    }
}
