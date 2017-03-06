namespace ForumMVC.App.Attributes
{
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    public class EmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string email = value.ToString();

            return email.Contains('@');
        }
    }
}
