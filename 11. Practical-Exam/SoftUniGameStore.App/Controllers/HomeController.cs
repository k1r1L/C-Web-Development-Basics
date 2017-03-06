namespace SoftUniGameStore.App.Controllers
{
    using Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;

    public class HomeController : Controller
    {
        private HomeService homeService;

        public HomeController()
        {
            this.homeService = new HomeService();
        }

        [HttpGet]
        public IActionResult<HomeViewModel> Index(HttpSession session)
        {
            HomeViewModel hvm = this.homeService.CreateHomeViewModel(session);
            return View(hvm);
        }

        [HttpGet]
        public IActionResult<CartViewModel> Cart(HttpSession session)
        {
            if (!this.homeService.CartExists(session.Id))
            {
                this.homeService.CreateNewCart(session.Id);
            }

            CartViewModel cvm = this.homeService.CreateCartViewModel(session);
            return View(cvm);
        }


        [HttpPost]
        public IActionResult Cart(HttpSession session, HttpResponse response)
        {
            if (!this.homeService.IsAuthenticated(session))
            {
                Redirect(response, "/users/login");
                return null;
            }

            this.homeService.Order(session);
            Redirect(response, "/users/profile");
            return null;
        }

        [HttpGet]
        public IActionResult Addtocart(int id, HttpSession session, HttpResponse response)
        {
            if (!this.homeService.CartExists(session.Id))
            {
                this.homeService.CreateNewCart(session.Id);
            }
            else
            {
                this.homeService.AddGameToCart(id, session.Id);
            }

            Redirect(response, "/home/cart");
            return null;
        }

        [HttpGet]
        public IActionResult Deletefromcart(int id, HttpSession session, HttpResponse response)
        {
            this.homeService.DeleteFromCart(id, session.Id);


            Redirect(response, "/home/cart");
            return null;
        }



    }
}
