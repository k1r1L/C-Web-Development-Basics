namespace SimpleMVC.App.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MVC.Attributes.Methods;
    using MVC.Controllers;
    using MVC.Interfaces;
    using BindingModels;
    using Models;
    using Data;
    using SimpleHttpServer.Models;
    using SimpleHttpServer.Enums;
    using MVC.Interfaces.Generic;
    using Security;

    public class UsersController : Controller
    {
        private SignInManager signInManager;
        public UsersController()
        {
            this.signInManager = new SignInManager(new PizzaMoreContext());
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(RegisterUserBindingModel model)
        {
            User user = new User()
            {
                Email = model.SignUpEmail,
                Password = model.SignUpPassword
            };

            using (PizzaMoreContext context = new PizzaMoreContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
                return Redirect("/users/signin");
            }
        }

        [HttpGet]
        public IActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signin(LoginUserBindingModel model, HttpSession httpSession)
        {
            using (PizzaMoreContext context = new PizzaMoreContext())
            {
                User existingUser = context.Users.FirstOrDefault(
                    user => user.Email == model.SignInEmail && user.Password == model.SignInPassword);

                if (existingUser != null && !context.Logins.Any(l => l.SessionId == httpSession.Id))
                {
                    Login login = new Login()
                    {
                        SessionId = httpSession.Id,
                        User = existingUser,
                        IsActive = true
                    };

                    context.Logins.Add(login);
                    context.SaveChanges();
                    return Redirect("/home/index");
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult Logout(HttpSession session)
        {
            this.signInManager.Logout(session);

            return Redirect("/home/index");
        }

        [HttpGet]
        public IActionResult Menu(HttpSession session)
        {
            if (!signInManager.IsAuthenticated(session))
            {
                Redirect("/home/index");
            }

            return View();
        }
    }
}
