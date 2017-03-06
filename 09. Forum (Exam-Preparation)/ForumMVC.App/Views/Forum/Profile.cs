namespace ForumMVC.App.Views.Forum
{
    using System.Text;
    using SimpleMVC.Interfaces.Generic;
    using Utillities;
    using ViewModels;

    public class Profile : IRenderable<ProfileViewModel>
    {
        public string Render()
        {
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.AppendLine(Reader.RetrieveContent(Constants.HeaderFolderLocation));
            htmlContent.AppendLine(NavbarGenerator.GenerateNavbar());
            StringBuilder topicsHtml = new StringBuilder();
            foreach (TopicViewModel modelUserTopic in this.Model.UserTopics)
            {
                if (this.Model.IsMine)
                {
                    topicsHtml.AppendLine(
                        $"<tr><td><a href=\"/topics/details?id={modelUserTopic.Id}\">{modelUserTopic.Title}</a></td>" +
                        $"<td><a href=\"/home/categories?categoryName={modelUserTopic.Category}\">{modelUserTopic.Category}</a></td>" +
                        $"<td>{modelUserTopic.PostedOn:dd-MMM-yyyy}</td>\r\n\t\t\t\t<td>{modelUserTopic.Replies}</td>" +
                        $"<td><a href=\"/topics/delete?id={modelUserTopic.Id}\" class=\"btn btn-danger\"/>Delete</a></td></tr>");
                }
                else
                {
                    topicsHtml.AppendLine($"<tr><td><a href=\"/topics/details?id={modelUserTopic.Id}\">{modelUserTopic.Title}</a></td>" +
                      $"<td><a href=\"/home/categories?categoryName={modelUserTopic.Category}\">{modelUserTopic.Category}</a></td>" +
                      $"<td>{modelUserTopic.PostedOn:dd-MMM-yyyy}</td>\r\n\t\t\t\t<td>{modelUserTopic.Replies}</td>\r\n\t\t\t</tr>");
                }
            }

            if (this.Model.IsMine)
            {
                htmlContent.AppendLine(string.Format(Reader.RetrieveContent(Constants.ProfileMineFolderLocation),
                    this.Model.Username, topicsHtml));
            }
            else
            {
                htmlContent.AppendLine(string.Format(Reader.RetrieveContent(Constants.ProfileOtherFolderLocation),
                   this.Model.Username, topicsHtml));
            }

            htmlContent.AppendLine(Reader.RetrieveContent(Constants.FooterFolderLocation));

            return htmlContent.ToString();
        }

        public ProfileViewModel Model { get; set; }
    }
}
