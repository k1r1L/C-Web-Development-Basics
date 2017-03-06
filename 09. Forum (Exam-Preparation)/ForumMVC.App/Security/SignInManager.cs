namespace ForumMVC.App.Security
{
    using System.Linq;
    using Data.Contracts;
    using Models;
    using SimpleHttpServer.Models;

    public class SignInManager
    {
        private IForumContext context;

        public SignInManager(IForumContext context)
        {
            this.context = context;
        }

        public bool IsAuthenticated(HttpSession session)
        {
            return this.context.Logins.Any(l => l.IsActive && l.SessionId == session.Id);
        }

        public bool IsAdmin(string sessionId)
        {
            Login currentLogin = this.context.Logins.FirstOrDefault
                (l => l.IsActive && l.SessionId == sessionId);

            if (currentLogin != null)
            {
                return currentLogin.User.Id == this.context.Users.First().Id;
            }

            return false;
        }
    }
}
