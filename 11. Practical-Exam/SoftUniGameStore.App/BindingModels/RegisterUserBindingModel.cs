namespace SoftUniGameStore.App.BindingModels
{
    using System.Text.RegularExpressions;

    public class RegisterUserBindingModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string FullName { get; set; }

        public bool IsValid()
        {
            if (!this.Email.Contains("@"))
            {
                return false;
            }

            if (!Regex.IsMatch(this.FullName, "^[a-zA-Z -.]+$"))
            {
                return false;
            }

            if (!Regex.IsMatch(this.Password, @"(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}"))
            {
                return false;
            }

            if (!Regex.IsMatch(this.ConfirmPassword, @"(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}"))
            {
                return false;
            }

            if (this.Password != this.ConfirmPassword)
            {
                return false;
            }

            return true;
        }
    }
}
