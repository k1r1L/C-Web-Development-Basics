namespace ForumMVC.App.Utillities
{
    using System.IO;

    public static class Reader
    {
        public static string RetrieveContent(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
