namespace ForumMVC.App.Controllers
{
    using BindingModels;
    using Security;
    using Services;
    using SimpleHttpServer.Models;
    using SimpleHttpServer.Utilities;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;

    public class ForumController : Controller
    {
        private ForumService service;
        private SignInManager signInManager;

        public ForumController()
        {
            this.service = new ForumService();
            this.signInManager = new SignInManager(this.service.Context);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel rubm, HttpResponse response)
        {
            if (this.service.RegisterUser(rubm))
            {
                this.Redirect(response, "/home/topics");
            }

            return this.View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }


        [HttpPost]
        public IActionResult Login(LoginUserBindingModel lubm, HttpSession session, HttpResponse response)
        {
            if (this.service.LoginUser(lubm, session.Id))
            {
                this.Redirect(response, "/home/topics");
            }

            return this.View();
        }


        [HttpGet]
        public void Logout(HttpResponse response, HttpSession session)
        {
            this.service.LogoutUser(session);
            var newSession = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", newSession.Id + "; HttpOnly; path=/");
            response.Header.Cookies["sessionId"] = sessionCookie;
            this.Redirect(response, "/home/topics");
        }

        [HttpGet]
        public IActionResult<ProfileViewModel> Profile(int id, HttpResponse response, HttpSession session)
        {
            if (!signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/home/login");
                return null;
            }

            ProfileViewModel vm = this.service.RetrieveProfile(id);

            return View(vm);
        }
    }
}
