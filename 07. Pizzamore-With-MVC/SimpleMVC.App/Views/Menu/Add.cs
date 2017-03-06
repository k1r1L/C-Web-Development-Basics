namespace SimpleMVC.App.Views.Menu
{
    using SimpleMVC.App.MVC.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Utillities;

    public class Add : IRenderable
    {
        public string Render()
        {
            string htmlContent = WebUtil.RetrieveFileContent(Constants.AddPizzaFolderLocation);

            return htmlContent;
        }
    }
}
