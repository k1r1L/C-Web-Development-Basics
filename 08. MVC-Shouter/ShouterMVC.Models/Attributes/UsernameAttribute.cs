namespace ShouterMVC.Models.Attributes
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    public class UsernameAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string username = value.ToString();
            string pattern = @"^[A-Za-z\d]+$";

            return Regex.IsMatch(username, pattern);
        }
    }
}
