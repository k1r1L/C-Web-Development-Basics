namespace ShouterMVC.App
{
    using ShouterMVC.App.Utillities;
    using SimpleHttpServer;
    using SimpleMVC;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AppStart
    {
        public static void Main(string[] args)
        {

            HttpServer httpServer = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(httpServer, "ShouterMVC.App");
        }

    }
}
