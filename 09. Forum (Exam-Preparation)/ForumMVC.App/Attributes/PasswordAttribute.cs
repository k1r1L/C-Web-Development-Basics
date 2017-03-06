namespace ForumMVC.App.Attributes
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    public class PasswordAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string password = value.ToString();
            string pattern = @"^\d{4}$";

            return Regex.IsMatch(password, pattern);
        }
    }
}
