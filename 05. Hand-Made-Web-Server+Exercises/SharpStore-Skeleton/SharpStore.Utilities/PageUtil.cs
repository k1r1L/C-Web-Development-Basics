namespace SharpStore.Utilities
{
    using Data;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;

    public static class PageUtil
    {
        public static void SendMessage(string queryString)
        {
            Dictionary<string, string> messageParameters = RetrieveRequestParameters(queryString);
            using (SharpStoreContext context = new SharpStoreContext())
            {
                context.Messages.Add(new Message()
                {
                    Sender = messageParameters["email"],
                    Subject = messageParameters["subject"],
                    MessageText = messageParameters["message"]
                });

                context.SaveChanges();
            }
        }

        public static string ProductsPageContent(string htmlFile, string queryString = null)
        {
            string filterCriteria = queryString != null ? RetrieveRequestParameters(queryString)["find"] : null;
            string productsHtml = File.ReadAllText($"../../../SharpStore/content/{htmlFile}");
            StringBuilder knivesHtml = new StringBuilder();
            using (SharpStoreContext context = new SharpStoreContext())
            {
                List<Knife> knivesInDb = queryString == null 
                    ? context.Knives.ToList() 
                    : context.Knives.Where(knife => knife.Name.Contains(filterCriteria)).ToList();

                foreach (Knife knive in knivesInDb)
                {
                    knivesHtml.AppendLine($@"<div class=""img-thumbnail col-lg-4 col-md-4"">
                                            <img src=""{knive.ImageUrl}"" alt="""" width=""300"" height=""150"">
                                            <h1>{knive.Name}</h1>
                                            <p>{knive.Price} $</p>
                                            <button class=""btn btn-primary"">Buy now</button>
                                            </div>");
                }
            }

            return string.Format(productsHtml.ToString(), knivesHtml);
        }

        public static Dictionary<string, string> RetrieveRequestParameters(string queryString)
        {
            queryString = WebUtility.UrlDecode(queryString);
            Dictionary<string, string> requestParameters = new Dictionary<string, string>();
            string[] parameters = queryString.Split('&');
            foreach (var param in parameters)
            {
                string[] pair = param.Split('=');

                string name = pair[0];
                string value = null;

                if (pair.Length > 1)
                {
                    value = pair[1];
                }

                if (!requestParameters.ContainsKey(name))
                {
                    requestParameters.Add(name, value);
                }
            }

            return requestParameters;
        }
    }
}
