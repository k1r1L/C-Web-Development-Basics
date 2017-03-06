using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShouterMVC.App.Views.Followers
{
    using System.IO;
    using SimpleMVC.Interfaces.Generic;
    using Utillities;
    using ViewModels;
    public class All : IRenderable<List<FollowersViewModel>>
    {
        public string Render()
        {
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.AppendLine(File.ReadAllText(Constants.AllFollowersFolderLocation));
            htmlContent = htmlContent.Replace("##username##", Helper.RetrieveUsernameHtml());

            StringBuilder allUsersHtml = new StringBuilder();
            foreach (FollowersViewModel followerViewModel in this.Model)
            {
                if (followerViewModel.Status == "Follow")
                {
                    allUsersHtml.AppendLine($@"  <li class=""list-group-item"">
                <form class=""form-group"" action=""/followers/all"" method=""POST"">
                        <h4>
                        <input type=""hidden"" name=""Id"" value=""{followerViewModel.UserId}""</input>
                            <strong><a class=""col-md-8""href=""/followers/profile?id={followerViewModel.UserId}"">{followerViewModel.Username}</a></strong>
                        <input type=""submit"" class=""btn btn-success"" value=""{followerViewModel.Status}""/>
                        </h4>
                </form>
            </li>");
                }
                else
                {

                    allUsersHtml.AppendLine($@"  <li class=""list-group-item"">
                <form class=""form-group"" action=""/followers/all"" method=""POST"">
                        <h4>
                        <input type=""hidden"" name=""Id"" value=""{followerViewModel.UserId}""</input>
                            <strong><a class=""col-md-8""href=""/followers/profile?id={followerViewModel.UserId}"">{followerViewModel.Username}</a></strong>
                        <input type=""submit"" class=""btn btn-danger"" value=""{followerViewModel.Status}""/>
                        </h4>
                </form>
            </li>");
                }
            }

            htmlContent = htmlContent.Replace("##users##", allUsersHtml.ToString());

            return htmlContent.ToString();
        }

        public List<FollowersViewModel> Model { get; set; }
    }
}
