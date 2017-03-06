namespace ShouterMVC.App.Views.Home
{
    using System.IO;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using Utillities;

    public class Login : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText(Constants.LoginFolderLocation);
        }
    }
}
