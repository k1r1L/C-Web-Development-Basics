namespace SimpleMVC.App.Views.Users
{
    using SimpleMVC.App.MVC.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Utillities;

    public class Signin : IRenderable
    {
        public string Render()
        {
            string htmlContent = WebUtil.RetrieveFileContent(Constants.SignInFolderLocation);

            return htmlContent;
        }
    }
}
