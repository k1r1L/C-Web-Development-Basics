namespace ShouterMVC.Models.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BirthdateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime birtdate = DateTime.Parse(value.ToString());
            int yearsOld = DateTime.Now.Year - birtdate.Year;

            return yearsOld >= 13;
        }
    }
}
