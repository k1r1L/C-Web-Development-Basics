namespace SoftUniGameStore.App.ViewModels
{
    using System.Collections.Generic;
    public class CartViewModel : NavbarViewModel
    {
        public IEnumerable<CartGameViewModel> Games { get; set; }

        public double TotalPrice { get; set; }
    }
}
