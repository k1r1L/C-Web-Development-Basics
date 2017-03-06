namespace SimpleMVC.App.Views.Users
{
    using SimpleMVC.App.MVC.Interfaces.Generic;
    using SimpleMVC.App.ViewModels;

    public class Greet : IRenderable<GreetViewModel>
    {
        public GreetViewModel Model { get; set; }

        public string Render()
        {
            string htmlContent = $"<p>Hello User with session id: {this.Model.SessionId}</p>";

            return htmlContent;
        }
    }
}
