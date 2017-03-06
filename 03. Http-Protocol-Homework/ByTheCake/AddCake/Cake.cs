using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddCake
{
    public class Cake
    {
        public string CakeName { get; set; }

        public decimal CakePrice { get; set; }

        public Cake(string cakeName, decimal cakePrice)
        {
            this.CakeName = cakeName;
            this.CakePrice = cakePrice;
        }
    }
}
