namespace Test
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ByTheCake
    {
        public static void Main(string[] args)
        {
            string type = "Content-Type: text/html\r\n";
            string output = File.ReadAllText(@"../htdocs/ByTheCake/index.html");
            Console.WriteLine(type);
            Console.WriteLine(output);
        }
    }
}

