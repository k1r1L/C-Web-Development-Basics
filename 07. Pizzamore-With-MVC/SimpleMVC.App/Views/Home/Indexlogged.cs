namespace SimpleMVC.App.Views.Home
{
    using SimpleMVC.App.MVC.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Utillities;
    public class Indexlogged : IRenderable
    {
        public string Render()
        {
            string htmlContent = WebUtil.RetrieveFileContent(Constants.HomeLoggedFolderLocation);

            return htmlContent;
        }
    }
}
