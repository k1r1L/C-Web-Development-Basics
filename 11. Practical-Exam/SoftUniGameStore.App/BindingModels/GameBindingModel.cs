namespace SoftUniGameStore.App.BindingModels
{
    using System.Text.RegularExpressions;

    public class GameBindingModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageThumbnail { get; set; }

        public double Price { get; set; }

        public double Size { get; set; }

        public string Trailer { get; set; }

        public string ReleaseDate { get; set; }

        public bool IsValid()
        {
            if (!Regex.IsMatch(this.Title, "[A-Z](.+){3,100}"))
            {
                return false;
            }

            if (this.Description.Length < 20)
            {
                return false;
            }

            if (this.Price < 0)
            {
                return false;
            }

            if (this.Size < 0)
            {
                return false;
            }

            if (this.Trailer.Length != 11)
            {
                return false;
            }

            if (this.ImageThumbnail != null && (this.ImageThumbnail.StartsWith("http:// ") 
                || this.ImageThumbnail.StartsWith("https:// ")))
            {
                return false;
            }


            return true;
        }
    }
}
