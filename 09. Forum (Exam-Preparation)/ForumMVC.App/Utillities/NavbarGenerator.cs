namespace ForumMVC.App.Utillities
{
    using Data;
    using Data.Repositories;
    using Models;

    public class NavbarGenerator
    {
        private static readonly LoginRepository loginRepository = new 
            LoginRepository(new ForumContext());

        public static string GenerateNavbar()
        {
            User currentlyLogged = loginRepository.RetrieveCurrentlyLogged();

            string navbar = Reader.RetrieveContent(Constants.NavbarLoggedFolderLocation);
            navbar = navbar.Replace("##username##",
                $"<a href=\"/forum/profile?id={currentlyLogged.Id}\">{currentlyLogged.Username}</a>");

            return navbar;
        }
    }
}
