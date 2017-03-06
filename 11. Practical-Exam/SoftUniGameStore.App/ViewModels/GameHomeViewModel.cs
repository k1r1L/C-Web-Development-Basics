namespace SoftUniGameStore.App.ViewModels
{
    public class GameHomeViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public double Size { get; set; }

        public double Price { get; set; }

        public string ImageThumbnail { get; set; }

        public override string ToString()
        {
            return "<div class=\"card col-4 thumbnail\"><img class=\"card-image-top img-fluid img-thumbnail\"" +
                   "onerror=\"this.src=\'https://www.weightwatchers.com/sites/all/themes/custom/wwvs_bts/assets/images/pl/fpo_16x9.png\';\"" +
                   $"src=\"{this.ImageThumbnail}\" width=\"300\" height=\"300\"/>\r\n" +
                   "<div class=\"card-block\">\r\n " +
                   $"<h4 class=\"card-title\">{this.Title}</h4>\r\n " +
                   $"<p class=\"card-text\"><strong>Price</strong> - {this.Price}&euro;</p>\r\n  " +
                   $"<p class=\"card-text\"><strong>Size</strong> - {this.Size} GB</p>\r\n" +
                   $"<p class=\"card-text\">{this.Description}</p>\r\n " +
                   $"</div>\r\n\r\n<div class=\"card-footer\">\r\n <a class=\"card-button btn btn-outline-primary\" name=\"delete\" href=\"/games/details?id={this.Id}\">Info</a>\r\n" +
                   $"<a class=\"card-button btn btn-primary\" name=\"buy\" href=\"/home/addtocart?id={this.Id}\">Buy</a>\r\n </div></div>";
        }
    }
}
