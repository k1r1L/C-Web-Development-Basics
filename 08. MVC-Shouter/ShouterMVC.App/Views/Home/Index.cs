using ShouterMVC.App.Utillities;
using SimpleMVC.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShouterMVC.App.Views.Home
{
    public class Index : IRenderable
    {
        public string Render()
        {
            string htmlContent = File.ReadAllText(Constants.IndexFolderLocation);

            return htmlContent;
        }
    }
}
