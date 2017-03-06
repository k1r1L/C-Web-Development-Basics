namespace ShouterMVC.Models.Attributes
{
    using System.ComponentModel.DataAnnotations;

    public class PasswordAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string password = value.ToString();

            return password.Length >= 3;
        }
    }
}
