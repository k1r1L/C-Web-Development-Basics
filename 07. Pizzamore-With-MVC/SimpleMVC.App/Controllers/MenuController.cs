namespace SimpleMVC.App.Controllers
{
    using AutoMapper;
    using BindingModels;
    using Models;
    using MVC.Interfaces.Generic;
    using SimpleHttpServer.Models;
    using SimpleMVC.App.Data;
    using SimpleMVC.App.MVC.Attributes.Methods;
    using SimpleMVC.App.MVC.Controllers;
    using SimpleMVC.App.MVC.Interfaces;
    using SimpleMVC.App.Security;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ViewModels;

    public class MenuController : Controller
    {
        private SignInManager signInManager;

        public MenuController()
        {
            this.signInManager = new SignInManager(new PizzaMoreContext());
        }

        [HttpGet]
        public IActionResult<UserMenuViewModel> Index(HttpSession session)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                return Redirect(new UserMenuViewModel(), "/game/index");
            }

            using (PizzaMoreContext context = new PizzaMoreContext())
            {
                User user = context.Logins
                    .First(l => l.SessionId == session.Id).User;
                UserMenuViewModel viewModel = new UserMenuViewModel()
                {
                    Email = user.Email,
                    Suggestions = user.PizzaSuggestions
                };

                return View(viewModel);
            }
        }

        [HttpGet]
        public IActionResult Add(HttpSession session)
        {
            if (!signInManager.IsAuthenticated(session))
            {
                return Redirect("/home/index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Add(AddPizzaBindingModel pizzaDto, HttpSession session)
        {
            try
            {
                using (PizzaMoreContext context = new PizzaMoreContext())
                {
                    ConfigureMapper(session, context);
                    Pizza pizzaEntity = Mapper.Map<Pizza>(pizzaDto);
                    context.Pizzas.Add(pizzaEntity);
                    context.SaveChanges();
                }

                return Redirect("/menu/index");
            }
            catch (DbEntityValidationException)
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult<SuggestionsViewModel> Suggestions(HttpSession session)
        {
            if (!signInManager.IsAuthenticated(session))
            {
                return Redirect(new SuggestionsViewModel(), "/home/index");
            }
            using (PizzaMoreContext context = new PizzaMoreContext())
            {
                User current = context.Logins.First(l => l.SessionId == session.Id).User;
                SuggestionsViewModel viewModel = new SuggestionsViewModel()
                {
                    PizzaSuggestions = current.PizzaSuggestions
                };

                return View(viewModel);
            }
        }

        [HttpPost]
        public IActionResult Suggestions(DeletePizzaBindingModel model, HttpSession session)
        {

            return View();
        }

        private static void ConfigureMapper(HttpSession session, PizzaMoreContext context)
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<AddPizzaBindingModel, Pizza>()
                .ForMember(p => p.Owner, configExpression => configExpression.MapFrom(u => context.Logins.First(l => l.SessionId == session.Id).User));
            });
        }
    }
}
