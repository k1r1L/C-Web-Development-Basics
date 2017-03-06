namespace PizzaMore.Utility
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Logger
    {
        public static void Log(string message)
        {
            File.AppendAllText(Constants.LogerPrintLocation, message + Environment.NewLine);
        }
    }
}
