namespace SimpleMVC.App.Views.Menu
{
    using MVC.Interfaces.Generic;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Utillities;
    using ViewModels;

    public class Suggestions : IRenderable<SuggestionsViewModel>
    {
        public SuggestionsViewModel Model { get; set; }


        public string Render()
        {
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.AppendLine(WebUtil.RetrieveFileContent(Constants.YourSuggestionsTopFolderLocation));
            htmlContent.AppendLine("<ul>");
            foreach (var suggestion in this.Model.PizzaSuggestions)
            {
                htmlContent.AppendLine("<form method=\"POST\">");
                htmlContent.AppendLine($"<li><a href=\"DetailsPizza.exe?pizzaid={suggestion.Id}\">{suggestion.Title}</a>" +
$"<input type=\"hidden\" name=\"SuggestionId\" value=\"{suggestion.Id}\"/>"
+ $"<button type=\"submit\"class=\"btn btn-sm btn-danger\">X</button></li>");
                htmlContent.AppendLine("</form>");
            }
            htmlContent.AppendLine("</ul>");

            htmlContent.AppendLine(WebUtil.RetrieveFileContent(Constants.YourSuggestionsBottomFolderLocation));

            return htmlContent.ToString();
        }
    }
}
