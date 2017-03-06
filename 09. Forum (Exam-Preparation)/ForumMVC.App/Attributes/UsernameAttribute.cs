namespace ForumMVC.App.Attributes
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    public class UsernameAttribute  : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string username = value.ToString();
            string pattern = @"^[a-z\d]{3,}$";

            return Regex.IsMatch(username, pattern);
        }
    }
}
