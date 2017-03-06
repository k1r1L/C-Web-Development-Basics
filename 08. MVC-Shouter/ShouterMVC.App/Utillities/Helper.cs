namespace ShouterMVC.App.Utillities
{
    using System;
    using System.Runtime.Remoting.Messaging;
    using System.Text;
    using System.Text.RegularExpressions;
    using Data;
    using Data.Repositories;
    using Models;

    public static class Helper
    {
        private static readonly LoginRepository repo = new LoginRepository(
            new ShouterContext());

        public static string RetrieveCurrent()
        {
            User currentUser = repo.RetrieveCurrentlyLogged();
            
            return currentUser.Username;
        }

        public static string RetrieveUsernameHtml()
        {
            User currentUser = repo.RetrieveCurrentlyLogged();
            string html =
               $"<a href=\"/followers/profile?id={currentUser.Id}\">" +
                $"{currentUser.Username}</a>";

            return html;
        }

        public static int RetrieveUsernameId(string username)
        {
            return repo.Find(l => l.User.Username == username).User.Id;
        }

        public static string RetrieveShoutContent(string shoutContent)
        {
            string[] shoutWords = shoutContent.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder newShoutContent = new StringBuilder();
            foreach (string shoutWord in shoutWords)
            {
                if (Regex.IsMatch(shoutWord, "http:\\/\\/|https:\\/\\/|www\\."))
                {
                    newShoutContent.Append(!shoutWord.Contains("http")
                        ? $"<a href=\"https://{shoutWord}\">{shoutWord}</a> "
                        : $"<a href=\"{shoutWord}\">{shoutWord}</a> ");
                }
                else
                {
                    newShoutContent.Append(shoutWord + " ");
                }
            }

            return newShoutContent.ToString();
        }
    }
}
