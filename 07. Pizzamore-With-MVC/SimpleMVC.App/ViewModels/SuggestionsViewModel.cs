namespace SimpleMVC.App.ViewModels
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SuggestionsViewModel
    {
        public ICollection<Pizza> PizzaSuggestions { get; set; }
    }
}
