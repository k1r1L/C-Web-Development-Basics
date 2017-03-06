namespace SimpleMVC.App.Controllers
{
    using Data;
    using MVC.Attributes.Methods;
    using MVC.Interfaces;
    using Security;
    using SimpleHttpServer.Models;
    using SimpleMVC.App.MVC.Controllers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class HomeController : Controller
    {
        private SignInManager signInManager;

        public HomeController()
        {
            this.signInManager = new SignInManager(new PizzaMoreContext());
        }

        [HttpGet]
        public IActionResult Index(HttpSession session)
        {
            if (this.signInManager.IsAuthenticated(session))
            {
                return Redirect("/home/indexlogged");
            }

            return View();
        }


        [HttpGet]
        public IActionResult Indexlogged(HttpSession session)
        {
            return View();
        }
    }
}
