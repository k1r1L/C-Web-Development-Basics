namespace AddCake
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;

    public class AddCake
    {
        public static void Main(string[] args)
        {
            string type = "Content-Type: text/html\r\n";
            string output = File.ReadAllText(@"../htdocs/ByTheCake/addcake.html");
            Console.WriteLine(type);
            Console.WriteLine(output);
            string postContent = Console.ReadLine();
            string[] postVariables = postContent.Split('&');
            string cakeName = WebUtility.UrlDecode(postVariables[0].Split('=')[1]);
            string cakePrice = WebUtility.UrlDecode(postVariables[1].Split('=')[1]);
            if (cakeName != string.Empty && cakePrice != string.Empty)
            {
                Cake torti4ka = new Cake(cakeName, decimal.Parse(cakePrice));
                Console.WriteLine($"<p>Cake Name: {torti4ka.CakeName}</p>");
                Console.WriteLine($"<p>Cake Price: {torti4ka.CakePrice}</p>");
                File.AppendAllText("../htdocs/ByTheCake/database.csv", $"{cakeName},{cakePrice}" + Environment.NewLine);
            }
            else
            {
                Console.WriteLine("<p>No info</p>");
            }
        }
    }
}
