namespace SoftUniGameStore.App.Controllers
{
    using BindingModels;
    using Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;

    public class UsersController : Controller
    {
        private UsersService usersService;

        public UsersController()
        {
            this.usersService = new UsersService();
        }

        [HttpGet]
        public IActionResult Register(HttpSession session, HttpResponse respone)
        {
            //if (this.usersService.IsAuthenticated(session))
            //{
            //    Redirect(respone, "/home/index");
            //    return null;
            //}


           return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel rubm, HttpSession session, HttpResponse respone)
        {
            //if (this.usersService.IsAuthenticated(session))
            //{
            //    Redirect(respone, "/home/index");
            //    return null;
            //}

            if (!rubm.IsValid())
            {
                Redirect(respone, "/users/register");
                return null;
            }

            this.usersService.RegisterUser(rubm);
            Redirect(respone, "/users/login");
            return null;
        }

        [HttpGet]
        public IActionResult Login (HttpSession session, HttpResponse respone)
        {
            if (this.usersService.IsAuthenticated(session))
            {
                Redirect(respone, "/home/index");
                return null;
            }


            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserBindingModel lubm, HttpSession session, HttpResponse respone)
        {
            if (this.usersService.IsAuthenticated(session))
            {
                Redirect(respone, "/home/index");
                return null;
            }

            if (!this.usersService.CanLogin(lubm))
            {
                Redirect(respone, "/users/login");
                return null;
            }

            this.usersService.LoginUser(lubm, session.Id);
            Redirect(respone, "/home/index");
            return null;
        }


        [HttpGet]
        public IActionResult Logout(HttpSession session, HttpResponse response)
        {
            if (this.usersService.IsAuthenticated(session))
            {
                this.usersService.LogoutUser(session.Id);
            }

            this.Redirect(response, "/home/index");
            return null;
        }

        [HttpGet]
        public IActionResult<ProfileViewModel> Profile(HttpSession session, HttpResponse response)
        {
            if (!this.usersService.IsAuthenticated(session))
            {
                Redirect(response, "/users/login");
                return null;
            }

            ProfileViewModel pvm = this.usersService.ReturnProfileViewModel();
            return View(pvm);
        }
    }
}
