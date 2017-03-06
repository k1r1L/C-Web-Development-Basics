namespace SoftUniGameStore.App.ViewModels
{
    public class GameDetailsViewModel : NavbarViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Trailer { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public double Size { get; set; }

        public string ReleaseDate { get; set; }

        public override string ToString()
        {
            return
                $"<main>\r\n<div class=\"container\">\r\n<div class=\"row\">\r\n<div class=\"col-12 text-center\">\r\n" +
                $"<h1 class=\"display-3\">{this.Title}</h1>\r\n<br/>\r\n" +
                "<iframe width=\"560\" height=\"315\" src=\"https://www.youtube.com/embed/{0}\" frameborder=\"0\" allowfullscreen></iframe>" +
                $" <br/><br/><p>{this.Description}</p><p><strong>Price</strong> - {this.Price}&euro;</p>\r\n<p><strong>Size</strong> - {this.Size} GB</p>" +
                $"<p><strong>Release Date</strong> - {this.ReleaseDate}</p><a class=\"btn btn-outline-primary\" name=\"delete\" href=\"/home/index\">Back</a>\r\n" +
                $"##admin##\r\n<a class=\"btn btn-primary\" name=\"buy\" href=\"/home/addtocart?id={this.Id}\">Buy</a>\r\n<br/>\r\n" +
                $"<br/>\r\n</div>\r\n</div>\r\n</div>\r\n</main>";
        }
    }
}
