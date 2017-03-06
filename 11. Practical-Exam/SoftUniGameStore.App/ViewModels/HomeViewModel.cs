namespace SoftUniGameStore.App.ViewModels
{
    using System.Collections.Generic;

    public class HomeViewModel : NavbarViewModel
    {
        public List<GameHomeViewModel> Games { get; set; }
    }
}
