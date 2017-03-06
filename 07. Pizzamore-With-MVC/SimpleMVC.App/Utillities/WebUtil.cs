namespace SimpleMVC.App.Utillities
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class WebUtil
    {
        public static string RetrieveFileContent(string path)
        {
            string content = File.ReadAllText(path);

            return content;
        }
    }
}
