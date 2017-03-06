namespace SimpleMVC.App.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BindingModels;
    using Data;
    using Models;
    using MVC.Attributes.Methods;
    using MVC.Controllers;
    using MVC.Interfaces;
    using MVC.Interfaces.Generic;
    using ViewModels;
    using System.Data.Entity;
    using SimpleHttpServer.Models;
    using MVC.Security;

    public class UsersController : Controller
    {
        private SignInManager signInManager;

        public UsersController()
        {
            this.signInManager = new SignInManager(new MvcAppContext());
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel model)
        {
            User user = new User()
            {
                Username = model.Username,
                Password = model.Password
            };

            using (MvcAppContext context = new MvcAppContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }

            return View();
        }

        [HttpGet]
        public IActionResult<AllUsernamesViewModel> All(HttpSession session)
        {
            List<UsernameAndIdViewModel> usernames = new List<UsernameAndIdViewModel>();

            if (!signInManager.IsAuthenticated(session))
            {
                return Redirect(new AllUsernamesViewModel() { UsernameIdForUsers = usernames }, "/users/login");
            }

            using (MvcAppContext context = new MvcAppContext())
            {
                if (context.Users == null)
                {
                    return View(new AllUsernamesViewModel());
                }
                usernames = context.Users.Select(
                    user => new UsernameAndIdViewModel()
                    {
                        Username = user.Username,
                        UserId = user.Id
                    }
                    ).ToList();
            }

            AllUsernamesViewModel viewModel = new AllUsernamesViewModel()
            {
                UsernameIdForUsers = usernames
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult<UserProfileViewModel> Profile(int id)
        {
            using (MvcAppContext context = new MvcAppContext())
            {
                User userEntity = context.Users.Find(id);
                UserProfileViewModel userModel = new UserProfileViewModel()
                {
                    UserId = userEntity.Id,
                    Username = userEntity.Username,
                    Notes = userEntity.Notes.Select(note => new NoteViewModel()
                    {
                        Title = note.Title,
                        Content = note.Content
                    })
                };

                return View(userModel);
            }
        }

        [HttpPost]
        public IActionResult<UserProfileViewModel> Profile(AddNoteBindingModel model)
        {
            using (MvcAppContext context = new MvcAppContext())
            {
                User owner = context.Users.Find(model.UserId);
                //context.Entry(owner).State = EntityState.Unchanged;
                Note noteEntity = new Note()
                {
                    Title = model.Title,
                    Content = model.Content,
                    Owner = owner
                };

                context.Notes.Add(noteEntity);
                context.SaveChanges();

                return Profile(model.UserId);
            }
        }

        public IActionResult<GreetViewModel> Greet(HttpSession session)
        {
            var viewModel = new GreetViewModel()
            {
                SessionId = session.Id
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserBindingModel model, HttpSession session)
        {
            string username = model.LoginUsername;
            string password = model.LoginPassword;
            string sessionId = session.Id;

            using (MvcAppContext context = new MvcAppContext())
            {
                User existingUser = context.Users
                  .FirstOrDefault(user => user.Username == username && user.Password == password);

                if (existingUser == null)
                {
                    return View();
                }

                if (context.Logins.Any(l => l.SessionId == sessionId))
                {
                    Login existsingLogin = context.Logins.First(l => l.SessionId == sessionId);
                    existsingLogin.IsActive = true;
                }
                else
                {
                    Login login = new Login()
                    {
                        SessionId = sessionId,
                        User = existingUser,
                        IsActive = true
                    };
                    context.Logins.Add(login);
                }

                context.SaveChanges();
            }


            return Redirect("/home/index");
        }


    }
}
