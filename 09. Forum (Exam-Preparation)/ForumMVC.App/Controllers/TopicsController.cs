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

    public class TopicsController : Controller
    {
        private TopicsService service;
        private SignInManager signInManager;

        public TopicsController()
        {
            this.service = new TopicsService();
            this.signInManager = new SignInManager(this.service.Context);
        }

        [HttpGet]
        public IActionResult<List<string>> New(HttpSession session, HttpResponse response)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/forum/login");
                return null;
            }

            return View(this.service.RetrieveAllCategories());
        }

        [HttpPost]
        public IActionResult New(HttpSession session, HttpResponse response, CreateTopicBindingModel ctbm)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/forum/login");
                return null;
            }

            this.service.CreateTopic(ctbm);

            Redirect(response, "/home/topics");
            return null;
        }

        [HttpGet]
        public IActionResult<TopicDetailsViewModel> Details(int id, HttpSession session, HttpResponse response)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/forum/login");
                return null;
            }

            TopicDetailsViewModel vm = this.service.RetreiveTopicDetailsViewModel(id);

            return View(vm);
        }

        [HttpPost]
        public IActionResult<TopicDetailsViewModel> Details(int id, CreateReplyBindingModel crbm , HttpSession session, HttpResponse response)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/forum/login");
                return null;
            }

            this.service.CreateReply(id, crbm);
            TopicDetailsViewModel vm = this.service.RetreiveTopicDetailsViewModel(id);

            return View(vm);
        }

        public void Delete(int id, HttpSession session, HttpResponse response)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/forum/login");
            }

            int userId = this.service.DeleteTopic(id);
            Redirect(response, $"/forum/profile?id={userId}");
        }
    }
}
