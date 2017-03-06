namespace SimpleMVC.App.Views.Users
{
    using MVC.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Utillities;

    public class Signup : IRenderable
    {
        public string Render()
        {
            string htmlContent = WebUtil.RetrieveFileContent(Constants.SignUpFolderLocation);

            return htmlContent;
        }
    }
}
