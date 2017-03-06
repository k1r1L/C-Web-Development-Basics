namespace ShouterMVC.App.Controllers
{
    using ShouterMVC.App.Security;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using BindingModels.BindingModels;
    using Data;
    using Data.Contracts;
    using Services;
    using SimpleHttpServer.Utilities;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;

    public class HomeController : Controller
    {
        private SignInManager signInManager;
        private HomeService homeService;

        public HomeController()
        {
            this.homeService = new HomeService();
            this.signInManager = new SignInManager(this.homeService.Context);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserBindingModel lubm, HttpResponse response, HttpSession session)
        {
            if (this.homeService.LoginUser(lubm, session.Id))
            {
                Redirect(response, "/home/feed");
                return null;
            }

            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel rubm, HttpResponse response)
        {
            if (this.homeService.RegisterUser(rubm))
            {
                Redirect(response, "/home/login");
                return null;
            }

            return View();
        }

        [HttpGet]
        public IActionResult<MainFeedViewModel> Feed()
        {
            MainFeedViewModel vm = this.homeService.RetrieveMainFeed();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Feed(CreateShoutBindingModel csbm, HttpResponse response)
        {
            this.homeService.CreateShout(csbm);
            Redirect(response, "/home/feed");
            return null;
        }

        [HttpGet]
        public IActionResult Logout(HttpResponse response, HttpSession session)
        {
            this.homeService.LogoutUser(session);
            var newSession = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", newSession.Id + "; HttpOnly; path=/");
            response.Header.Cookies["sessionId"] = sessionCookie;
            Redirect(response, "/home/feed");
            return null;
        }
    }
}
