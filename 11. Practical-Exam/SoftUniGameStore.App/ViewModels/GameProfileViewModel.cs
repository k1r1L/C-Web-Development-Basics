namespace SoftUniGameStore.App.ViewModels
{
    public class GameProfileViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public double Size { get; set; }

        public double Price { get; set; }

        public string ImageThumbnail { get; set; }

        public string ReleaseDate { get; set; }

        public override string ToString()
        {
            return "<div class=\"card col-4 thumbnail\">" +
                   "<img class=\"card-image-top img-fluid img-thumbnail\" onerror=\"this.src=\'https://i.ytimg.com/vi/BqJyluskTfM/maxresdefault.jpg\';\"" +
                   $"src=\"{this.ImageThumbnail}\">" +
                   $"<div class=\"card-block\"> <h4 class=\"card-title\">{this.Title}</h4><p class=\"card-text\"><strong>Size</strong> - {this.Size} GB</p>" +
                   $"<p class=\"card-text\"><strong>Bought on</strong> - {this.ReleaseDate}</p><p class=\"card-text\">{this.Description}</p></div>" +
                   "<div class=\"card-footer\"><input type=\"submit\" class=\"btn btn-outline-info\" disabled value=\"Play\"/></div></div>";
        }
    }
}
