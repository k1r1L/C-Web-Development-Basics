namespace SimpleMVC.App.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MVC.Controllers;
    using MVC.Interfaces;
    using MVC.Attributes.Methods;
    using SimpleHttpServer.Models;
    using MVC.Security;
    using Data;
    using SimpleHttpServer.Utilities;

    public class HomeController : Controller
    {
        private SignInManager signInManager;

        public HomeController()
        {
            this.signInManager = new SignInManager(new MvcAppContext());
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(HttpSession session)
        {
            this.signInManager.LogoutUser(session);

            return View();
        }
    }
}
