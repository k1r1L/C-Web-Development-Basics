namespace SoftUniGameStore.App.ViewModels
{
    public class AdminGameViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Size { get; set; }

        public double Price { get; set; }

        public override string ToString()
        {
            return $"<tr class=\"table-warning\">\r\n <th scope=\"row\">{this.Id}</th>\r\n" +
                   $"<td>{this.Name}</td>\r\n          " +
                   $"<td>{this.Size} GB</td>\r\n" +
                   $" <td>{this.Price} &euro;</td>\r\n <td>" +
                   $"<a href=\"/games/edit?id={this.Id}\" class=\"btn btn-warning btn-sm\">Edit</a>\r\n" +
                   $"<a href=\"/games/delete?id={this.Id}\" class=\"btn btn-danger btn-sm\">Delete</a> </td></tr>";
        }
    }
}
