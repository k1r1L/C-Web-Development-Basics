namespace SimpleMVC.App.Views.Game
{
    using SimpleMVC.App.MVC.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Utillities;

    public class Index : IRenderable
    {
        public string Render()
        {
            string htmlContent = WebUtil.RetrieveFileContent(Constants.GameFolderLocation);

            return htmlContent;
        }
    }
}
