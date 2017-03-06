namespace SoftUniGameStore.App.ViewModels
{
    public class CartGameViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageThumbnail { get; set; }

        public double Price { get; set; }

        public override string ToString()
        {
            return $"<form method=\"GET\" action=\"/home/deletefromcart\"><div class=\"list-group-item\">" +
                   $"<input type=\"hidden\" name=\"id\" value=\"{this.Id}\">" +
                   $"<button type=\"submit\" class=\"btn btn-outline-danger btn-lg\"\">X</button>\r\n" +
                   "<div class=\"media col-3\"><figure class=\"pull-left\">" +
                   "<a href=\"#\"><img\r\nclass=\"card-image-top img-fluid img-thumbnail\"" +
                   "onerror=\"this.src=\'https://www.weightwatchers.com/sites/all/themes/custom/wwvs_bts/assets/images/pl/fpo_16x9.png\';\"" +
                   $"src=\"{this.ImageThumbnail}\"></a>\r\n </figure>\r\n  </div>\r\n <div class=\"col-md-6\">\r\n<a href=\"#\"><h4 class=\"list-group-item-heading\"> {this.Title} </h4></a>\r\n" +
                   $"<p class=\"list-group-item-text\"> {this.Description}\r\n</p>\r\n</div>\r\n" +
                   $"<div class=\"col-md-2 text-center mr-auto\">\r\n  <h2> {this.Price}&euro; </h2>\r\n</div>\r\n</div></form>";
        }
    }
}
