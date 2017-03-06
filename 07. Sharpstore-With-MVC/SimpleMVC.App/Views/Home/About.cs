namespace SimpleMVC.App.Views.Home
{
    using SimpleMVC.App.MVC.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class About : IRenderable
    {

        public string Render()
        {
            string htmlContent = File.ReadAllText("../../content/about.html");

            return htmlContent;
        }
    }
}
