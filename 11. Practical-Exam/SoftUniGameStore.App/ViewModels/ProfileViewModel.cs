namespace SoftUniGameStore.App.ViewModels
{
    using System.Collections.Generic;

    public class ProfileViewModel : NavbarViewModel
    {
        public List<GameProfileViewModel> Games { get; set; }
    }
}
