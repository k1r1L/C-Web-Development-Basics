namespace SoftUniGameStore.App.Controllers
{
    using System.Collections.Generic;
    using BindingModels;
    using Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;

    public class GamesController : Controller
    {
        private GamesService gamesService;

        public GamesController()
        {
            this.gamesService = new GamesService();
        }

        [HttpGet]
        public IActionResult<List<AdminGameViewModel>> All(HttpSession httpSession, HttpResponse response)
        {
            if (!this.gamesService.IsAuthenticated(httpSession))
            {
                Redirect(response, "/users/login");
                return null;
            }

            if (!this.gamesService.IsAdmin())
            {
                Redirect(response, "/home/index");
                return null;
            }

            List<AdminGameViewModel> vm = this.gamesService.RetrieveAllGames();

            return View(vm);
        }

        [HttpGet]
        public IActionResult Add(HttpSession httpSession, HttpResponse response)
        {
            if (!this.gamesService.IsAuthenticated(httpSession))
            {
                Redirect(response, "/users/login");
                return null;
            }

            if (!this.gamesService.IsAdmin())
            {
                Redirect(response, "/home/index");
                return null;
            }

            return View();
        }

        [HttpPost]
        public IActionResult Add(GameBindingModel agbm, HttpSession httpSession, HttpResponse response)
        {
            if (!this.gamesService.IsAuthenticated(httpSession))
            {
                Redirect(response, "/users/login");
                return null;
            }

            if (!this.gamesService.IsAdmin())
            {
                Redirect(response, "/home/index");
                return null;
            }

            if (!agbm.IsValid())
            {
                Redirect(response, "/games/add");
                return null;
            }

            this.gamesService.AddGame(agbm);
            Redirect(response, "/games/all");
            return null;
        }

        [HttpGet]
        public IActionResult<EditGameViewModel> Edit(int id, HttpSession httpSession, HttpResponse response)
        {
            if (!this.gamesService.IsAuthenticated(httpSession))
            {
                Redirect(response, "/users/login");
                return null;
            }

            if (!this.gamesService.IsAdmin())
            {
                Redirect(response, "/home/index");
                return null;
            }

            EditGameViewModel egvm = this.gamesService.CreateEditGameViewModel(id);

            return View(egvm);
        }

        [HttpPost]
        public IActionResult Edit(int id, GameBindingModel agbm, HttpSession httpSession, HttpResponse response)
        {
            if (!this.gamesService.IsAuthenticated(httpSession))
            {
                Redirect(response, "/users/login");
                return null;
            }

            if (!this.gamesService.IsAdmin())
            {
                Redirect(response, "/home/index");
                return null;
            }

            if (!agbm.IsValid())
            {
                Redirect(response, "/games/add");
                return null;
            }

            this.gamesService.EditGame(id, agbm);
            Redirect(response, "/games/all");
            return null;
        }

        [HttpGet]
        public IActionResult<int> Delete(int id, HttpSession httpSession, HttpResponse response, HttpRequest request)
        {
            if (!this.gamesService.IsAuthenticated(httpSession))
            {
                Redirect(response, "/users/login");
                return null;
            }

            if (!this.gamesService.IsAdmin())
            {
                Redirect(response, "/home/index");
                return null;
            }

            return View(id);
        }

        [HttpPost]
        public IActionResult Delete(int id, HttpSession httpSession, HttpResponse response)
        {
            if (!this.gamesService.IsAuthenticated(httpSession))
            {
                Redirect(response, "/users/login");
                return null;
            }

            if (!this.gamesService.IsAdmin())
            {
                Redirect(response, "/home/index");
                return null;
            }

            this.gamesService.DeleteGame(id);

            Redirect(response, "/games/all");
            return null;
        }

        [HttpGet]
        public IActionResult<GameDetailsViewModel> Details(int id, HttpSession session)
        {
            GameDetailsViewModel gdvm = this.gamesService.CreateGameDetailsViewModel(id, session);
            return View(gdvm);
        }
    }
}
