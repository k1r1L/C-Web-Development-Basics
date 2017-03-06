namespace ForumMVC.App.Controllers
{
    using System.Collections.Generic;
    using Security;
    using Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;

    public class HomeController : Controller
    {
        private HomeService service;
        private SignInManager signInManager;

        public HomeController()
        {
            this.service = new HomeService();
            this.signInManager = new SignInManager(this.service.Context);
        }

        [HttpGet]
        public IActionResult<TopTenTopicsViewModel> Topics(HttpSession session, HttpResponse response)
        {
            TopTenTopicsViewModel viewModel = this.service
                .RetrieveTopTen(this.signInManager.IsAuthenticated(session));

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult<List<string>> Categories(HttpSession session, HttpResponse response)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/forum/login");
                return null;
            }

            return View(this.service.GetAllCategories());
        }

        [HttpGet]
        public IActionResult<List<TopicViewModel>> Category(string categoryName, HttpSession session, HttpResponse response)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/forum/login");
                return null;
            }

            return View(this.service.GetAllTopicsInCategory(categoryName));

        }
    }
}
