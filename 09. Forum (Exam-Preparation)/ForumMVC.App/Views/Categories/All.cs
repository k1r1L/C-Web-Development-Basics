namespace ForumMVC.App.Views.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Models;
    using SimpleMVC.Interfaces.Generic;
    using Utillities;
    using ViewModels;

    public class All : IRenderable<List<CategoryViewModel>>
    {
        public string Render()
        {
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.AppendLine(Reader.RetrieveContent(Constants.HeaderFolderLocation));

            htmlContent.AppendLine(NavbarGenerator.GenerateNavbar());

            StringBuilder allCategoriesHtml = new StringBuilder();
            foreach (CategoryViewModel category in this.Model)
            {
                allCategoriesHtml.AppendLine($"<tr>\r\n\t\t\t\t<td><a href=\"/categories/topics?categoryName={category.CategoryName}\">{category.CategoryName}</a></td>\r\n\t\t\t\t<td>" +
                                       $"<a href=\"/categories/edit?id={category.Id}\" class=\"btn btn-primary\"/>Edit</a></td><td>" +
                                       $"<a href=\"/categories/delete?id={category.Id}\" class=\"btn btn-danger\"/>Delete</a></td></tr>");
            }

            htmlContent.AppendLine(string.Format(Reader.RetrieveContent(Constants.CategoriesAllFolderLocation),
                allCategoriesHtml));
            htmlContent.AppendLine(Reader.RetrieveContent(Constants.FooterFolderLocation));

            return htmlContent.ToString();
        }

        public List<CategoryViewModel> Model { get; set; }
    }
}
