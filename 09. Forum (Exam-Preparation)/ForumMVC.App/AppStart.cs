namespace ForumMVC.App
{
    using SimpleHttpServer;
    using SimpleMVC;
    using Utillities;

    public class AppStart
    {
        public static void Main(string[] args)
        {
            HttpServer httpServer = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(httpServer, "ForumMVC.App");
        }
    }
}
