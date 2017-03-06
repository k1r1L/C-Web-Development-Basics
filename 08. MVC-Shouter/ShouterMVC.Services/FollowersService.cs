namespace ShouterMVC.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Models;
    using ViewModels;

    public class FollowersService : Service
    {
        public UserProfileViewModel CreateUserProfile(int id)
        {
            User userEntity = this.UsersRepository.Find(id);
            User currentUser = this.LoginRepository.RetrieveCurrentlyLogged();
            bool isFollowing = currentUser.Following.Contains(userEntity);
            string username = userEntity.Username;
            List<Shout> shouts = userEntity.Shouts.ToList();
            List<ShoutViewModel> svm = new List<ShoutViewModel>();
            ConfigureMapper();
            foreach (Shout shout in shouts)
            {
                svm.Add(Mapper.Map<ShoutViewModel>(shout));
            }

            return new UserProfileViewModel()
            {
                Username = username,
                Shouts = svm,
                IsFollowing = isFollowing
            };
        }

        public void FollowOrUnfollowUser(int id)
        {
            User userEntity = this.UsersRepository.Find(id);
            User currentUser = this.LoginRepository.RetrieveCurrentlyLogged();
            bool isFollowing = currentUser.Following.Contains(userEntity);

            if (isFollowing)
            {
                currentUser.Following.Remove(userEntity);
            }
            else
            {
                currentUser.Following.Add(userEntity);
            }

            this.SaveChanges();
        }

        public List<FollowersViewModel> RetrieveAllFollowers(string filter = null)
        {
            List<FollowersViewModel> vmList = new List<FollowersViewModel>();
            User currentUser = this.LoginRepository.RetrieveCurrentlyLogged();
            List<User> allUsers = this.UsersRepository
                .All(u => u.Id != currentUser.Id)
                .ToList();

            if (filter != null)
            {
                allUsers = allUsers.Where(u => u.Username.Contains(filter)).ToList();
            }

            foreach (User user in allUsers)
            {
                vmList.Add(new FollowersViewModel()
                {
                    UserId = user.Id,
                    Username = user.Username,
                    Status = currentUser.Following.Contains(user) ? "Unfollow" : "Follow"
                });
            }

            return vmList;
        }
    }
}
