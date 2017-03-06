namespace ShouterMVC.App.Controllers
{
    using SimpleMVC.Controllers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BindingModels.BindingModels;
    using Security;
    using Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;

    public class FollowersController : Controller
    {
        private SignInManager signInManager;
        private FollowersService followersService;

        public FollowersController()
        {
            this.followersService = new FollowersService();
            this.signInManager = new SignInManager(this.followersService.Context);
        }

        [HttpGet]
        public IActionResult<UserProfileViewModel> Profile(int id, HttpResponse response, HttpSession session)
        {
            if (!signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/home/login");
                return null;
            }

            UserProfileViewModel vm = this.followersService.CreateUserProfile(id);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Profile(int id, HttpResponse response)
        {
            this.followersService.FollowOrUnfollowUser(id);
            Redirect(response, $"/followers/profile?id={id}");
            return null;
        }

        [HttpGet]
        public IActionResult<List<FollowersViewModel>> All(HttpResponse response, HttpSession session, string filter = null)
        {
            if (!signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/home/login");
                return null;
            }

            List<FollowersViewModel> vm = this.followersService.RetrieveAllFollowers(filter);

            return View(vm);
        }

        [HttpPost]
        public IActionResult<List<FollowersViewModel>> All(HttpResponse response, HttpSession session, FollowerBindingModel fbm)
        {
            if (!signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/home/login");
                return null;
            }

            this.followersService.FollowOrUnfollowUser(fbm.Id);
            Redirect(response, "/followers/all");
            return null;
        }
    }
}
