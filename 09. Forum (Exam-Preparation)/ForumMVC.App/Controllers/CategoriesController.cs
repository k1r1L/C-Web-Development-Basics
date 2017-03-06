namespace ForumMVC.App.Controllers
{
    using System.Collections.Generic;
    using BindingModels;
    using Security;
    using Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;

    public class CategoriesController : Controller
    {
        private CategoriesService service;
        private SignInManager signInManager;

        public CategoriesController()
        {
            this.service = new CategoriesService();
            this.signInManager = new SignInManager(this.service.Context);
        }

        [HttpGet]
        public IActionResult<List<CategoryViewModel>> All(HttpSession session, HttpResponse response)
        {
            if (!signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/forum/login");
                return null;
            }

            if (!this.signInManager.IsAdmin(session.Id))
            {
                Redirect(response, "/home/topics");
                return null;
            }


            return View(this.service.RetrieveAll());
        }

        [HttpGet]
        public IActionResult New(HttpSession session, HttpResponse response)
        {
            if (!signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/forum/login");
                return null;
            }

            if (!this.signInManager.IsAdmin(session.Id))
            {
                Redirect(response, "/home/topics");
                return null;
            }


            return View();
        }

        [HttpPost]
        public IActionResult New(CreateCategoryBindingModel ccbm, HttpResponse response)
        {
            if (this.service.CreateCategory(ccbm))
            {
                Redirect(response, "/categories/all");
                return null;
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(HttpSession session, HttpResponse response, int id)
        {
            if (!signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/forum/login");
                return null;
            }

            if (!this.signInManager.IsAdmin(session.Id))
            {
                Redirect(response, "/home/topics");
                return null;
            }


            return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, CreateCategoryBindingModel ccbm, HttpResponse response)
        {
            this.service.EditCategory(id, ccbm.CategoryName);
            Redirect(response, "/categories/all");
            return null;
        }

        public IActionResult Delete(int id, HttpResponse response)
        {
            this.service.DeleteCategory(id);
            Redirect(response, "/categories/all");
            return null;
        }
    }
}
